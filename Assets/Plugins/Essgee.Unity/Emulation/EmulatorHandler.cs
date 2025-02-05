﻿using Essgee.Emulation.Configuration;
using Essgee.Emulation.Machines;
using Essgee.EventArguments;
using Essgee.Metadata;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace Essgee.Emulation
{
    public class EmulatorHandler
    {
        readonly Action<Exception> exceptionHandler;

        public IMachine emulator { get; private set; }

        Thread emulationThread;
        volatile bool emulationThreadRunning;

        volatile bool limitFps;
        volatile bool emulationThreadPaused;

        volatile bool configChangeRequested = false;
        volatile IConfiguration newConfiguration = null;

        volatile bool stateLoadRequested = false, stateSaveRequested = false;
        volatile int stateNumber = -1;

        volatile Queue<bool> pauseStateChangesRequested = new Queue<bool>();

        public event EventHandler<SendLogMessageEventArgs> SendLogMessage
        {
            add { emulator.SendLogMessage += value; }
            remove { emulator.SendLogMessage -= value; }
        }

        public event EventHandler<EventArgs> EmulationReset
        {
            add { emulator.EmulationReset += value; }
            remove { emulator.EmulationReset -= value; }
        }

        public event EventHandler<RenderScreenEventArgs> RenderScreen
        {
            add { emulator.RenderScreen += value; }
            remove { emulator.RenderScreen -= value; }
        }

        public event EventHandler<SizeScreenEventArgs> SizeScreen
        {
            add { emulator.SizeScreen += value; }
            remove { emulator.SizeScreen -= value; }
        }

        public event EventHandler<ChangeViewportEventArgs> ChangeViewport
        {
            add { emulator.ChangeViewport += value; }
            remove { emulator.ChangeViewport -= value; }
        }

        public event EventHandler<PollInputEventArgs> PollInput
        {
            add { emulator.PollInput += value; }
            remove { emulator.PollInput -= value; }
        }

        public event EventHandler<EnqueueSamplesEventArgs> EnqueueSamples
        {
            add { emulator.EnqueueSamples += value; }
            remove { emulator.EnqueueSamples -= value; }
        }

        public event EventHandler<SaveExtraDataEventArgs> SaveExtraData
        {
            add { emulator.SaveExtraData += value; }
            remove { emulator.SaveExtraData -= value; }
        }

        public event EventHandler<EventArgs> EnableRumble
        {
            add { emulator.EnableRumble += value; }
            remove { emulator.EnableRumble -= value; }
        }

        public event EventHandler<EventArgs> PauseChanged;

        GameMetadata currentGameMetadata;

        public bool IsCartridgeLoaded { get; private set; }

        public bool IsRunning => emulationThreadRunning;
        public bool IsPaused => emulationThreadPaused;

        public bool IsHandlingSaveState => (stateLoadRequested || stateSaveRequested);

        public (string Manufacturer, string Model, string DatFileName, double RefreshRate, double PixelAspectRatio, (string Name, string Description)[] RuntimeOptions) Information =>
            (emulator.ManufacturerName, emulator.ModelName, emulator.DatFilename, emulator.RefreshRate, emulator.PixelAspectRatio, emulator.RuntimeOptions);

        public EmulatorHandler(Type type, Action<Exception> exceptionHandler = null)
        {
            this.exceptionHandler = exceptionHandler;

            emulator = (IMachine)Activator.CreateInstance(type);
        }

        public void SetConfiguration(IConfiguration config)
        {
            if (emulationThreadRunning)
            {
                configChangeRequested = true;
                newConfiguration = config;
            }
            else
                emulator.SetConfiguration(config);
        }

        public void Initialize()
        {
            emulator.Initialize();
        }

        public void Startup()
        {
            emulationThreadRunning = true;
            emulationThreadPaused = false;

            emulator.Startup();
            emulator.Reset();

            emulationThread = new Thread(ThreadMainLoop) { Name = "EssgeeEmulation", Priority = ThreadPriority.Normal };
            emulationThread.Start();
        }

        public void Reset()
        {
            emulator.Reset();
        }

        public void Shutdown()
        {
            emulationThreadRunning = false;

            emulationThread?.Join();

            emulator.Shutdown();
        }

        public void Pause(bool pauseState)
        {
            pauseStateChangesRequested.Enqueue(pauseState);
        }

        public string GetSaveStateFilename(int number)
        {
            return Path.Combine(EmuStandInfo.SaveStatePath, $"{Path.GetFileNameWithoutExtension(currentGameMetadata.FileName)} (State {number:D2}).est");
        }

        public void LoadState(int number)
        {
            stateLoadRequested = true;
            stateNumber = number;
        }

        public void SaveState(int number)
        {
            stateSaveRequested = true;
            stateNumber = number;
        }

        public void LoadCartridge(byte[] romData, GameMetadata gameMetadata)
        {
            currentGameMetadata = gameMetadata;

            byte[] ramData = new byte[currentGameMetadata.RamSize];

            var savePath = Path.Combine(EmuStandInfo.SaveDataPath, Path.ChangeExtension(currentGameMetadata.FileName, "sav"));
            if (File.Exists(savePath))
                ramData = File.ReadAllBytes(savePath);

            emulator.Load(romData, ramData, currentGameMetadata.MapperType);

            IsCartridgeLoaded = true;
        }

        public void SaveCartridge()
        {
            if (currentGameMetadata == null) return;

            var cartRamSaveNeeded = emulator.IsCartridgeRamSaveNeeded();
            if ((cartRamSaveNeeded && currentGameMetadata.MapperType != null && currentGameMetadata.HasNonVolatileRam) ||
                cartRamSaveNeeded)
            {
                var ramData = emulator.GetCartridgeRam();
                var savePath = Path.Combine(EmuStandInfo.SaveDataPath, Path.ChangeExtension(currentGameMetadata.FileName, "sav"));
                File.WriteAllBytes(savePath, ramData);
            }
        }

        public Dictionary<string, dynamic> GetDebugInformation()
        {
            return emulator.GetDebugInformation();
        }

        public Type GetMachineType()
        {
            return emulator.GetType();
        }

        public void SetFpsLimiting(bool value)
        {
            limitFps = value;
        }

        public object GetRuntimeOption(string name)
        {
            return emulator.GetRuntimeOption(name);
        }

        public void SetRuntimeOption(string name, object value)
        {
            emulator.SetRuntimeOption(name, value);
        }

        public int FramesPerSecond { get; private set; }

        private void ThreadMainLoop()
        {
            // TODO: rework fps limiter/counter - AGAIN - because the counter is inaccurate at sampleTimespan=0.25 and the limiter CAN cause sound crackling at sampleTimespan>0.25
            // try this maybe? https://stackoverflow.com/a/34839411

            var stopWatch = Stopwatch.StartNew();

            TimeSpan accumulatedTime = TimeSpan.Zero, lastStartTime = TimeSpan.Zero, lastEndTime = TimeSpan.Zero;

            var frameCounter = 0;
            var sampleTimespan = TimeSpan.FromSeconds(0.5);

            try
            {
                while (true)
                {
                    if (!emulationThreadRunning)
                        break;

                    if (stateLoadRequested && stateNumber != -1)
                    {
                        var statePath = GetSaveStateFilename(stateNumber);
                        if (File.Exists(statePath))
                        {
                            using (var stream = new FileStream(statePath, FileMode.Open))
                            {
                                emulator.SetState(SaveStateHandler.Load(stream, emulator.GetType().Name));
                            }
                        }

                        stateLoadRequested = false;
                        stateNumber = -1;
                    }

                    var refreshRate = emulator.RefreshRate;
                    var targetElapsedTime = TimeSpan.FromTicks((long)Math.Round(TimeSpan.TicksPerSecond / refreshRate));

                    var startTime = stopWatch.Elapsed;

                    while (pauseStateChangesRequested.Count > 0)
                    {
                        var newPauseState = pauseStateChangesRequested.Dequeue();
                        emulationThreadPaused = newPauseState;

                        PauseChanged?.Invoke(this, EventArgs.Empty);
                    }

                    if (!emulationThreadPaused)
                    {
                        if (limitFps)
                        {
                            var elapsedTime = (startTime - lastStartTime);
                            lastStartTime = startTime;

                            if (elapsedTime < targetElapsedTime)
                            {
                                accumulatedTime += elapsedTime;

                                while (accumulatedTime >= targetElapsedTime)
                                {
                                    emulator.RunFrame();
                                    frameCounter++;

                                    accumulatedTime -= targetElapsedTime;
                                }
                            }
                        }
                        else
                        {
                            emulator.RunFrame();
                            frameCounter++;
                        }

                        if ((stopWatch.Elapsed - lastEndTime) >= sampleTimespan)
                        {
                            FramesPerSecond = (int)((frameCounter * 1000.0) / sampleTimespan.TotalMilliseconds);
                            frameCounter = 0;
                            lastEndTime = stopWatch.Elapsed;
                        }
                    }
                    else
                    {
                        lastEndTime = stopWatch.Elapsed;
                    }

                    if (configChangeRequested)
                    {
                        emulator.SetConfiguration(newConfiguration);
                        configChangeRequested = false;
                    }

                    if (stateSaveRequested && stateNumber != -1)
                    {
                        var statePath = GetSaveStateFilename(stateNumber);
                        using (var stream = new FileStream(statePath, FileMode.OpenOrCreate))
                        {
                            SaveStateHandler.Save(stream, emulator.GetType().Name, emulator.GetState());
                        }

                        stateSaveRequested = false;
                        stateNumber = -1;
                    }
                }
            }
            catch (Exception ex) when (!AppEnvironment.DebugMode)
            {
                ex.Data.Add("Thread", Thread.CurrentThread.Name);
                exceptionHandler(ex);
            }
        }
    }
}
