﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Essgee.EventArguments;
using Essgee.Emulation.Configuration;

namespace Essgee.Emulation.Machines
{
	public interface IMachine
	{
		event EventHandler<SendLogMessageEventArgs> SendLogMessage;
		event EventHandler<EventArgs> EmulationReset;
		event EventHandler<RenderScreenEventArgs> RenderScreen;
		event EventHandler<SizeScreenEventArgs> SizeScreen;
		event EventHandler<ChangeViewportEventArgs> ChangeViewport;
		event EventHandler<PollInputEventArgs> PollInput;
		event EventHandler<EnqueueSamplesEventArgs> EnqueueSamples;
		event EventHandler<SaveExtraDataEventArgs> SaveExtraData;
		event EventHandler<EventArgs> EnableRumble;

		string ManufacturerName { get; }
		string ModelName { get; }
		string DatFilename { get; }
		(string Extension, string Description) FileFilter { get; }
		bool HasBootstrap { get; }
		double RefreshRate { get; }
		double PixelAspectRatio { get; }
		(string Name, string Description)[] RuntimeOptions { get; }

		Dictionary<string, dynamic> GetDebugInformation();

		void SetConfiguration(IConfiguration config);

		object GetRuntimeOption(string name);
		void SetRuntimeOption(string name, object value);

		void Initialize();
		void Startup();
		void Reset();
		void Shutdown();

		void SetState(Dictionary<string, dynamic> state);
		Dictionary<string, dynamic> GetState();

		void Load(byte[] romData, byte[] ramData, Type mapperType);
		byte[] GetCartridgeRam();
		bool IsCartridgeRamSaveNeeded();

		void RunFrame();
	}
}
