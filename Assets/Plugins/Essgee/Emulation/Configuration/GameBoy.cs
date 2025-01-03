using Essgee.Emulation.Cartridges.Nintendo;
using Essgee.Emulation.ExtDevices.Nintendo;
using Essgee.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Essgee.Emulation.Configuration
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ElementPriorityAttribute : Attribute
    {
        public int Priority { get; set; }

        public ElementPriorityAttribute(int priority)
        {
            Priority = priority;
        }
    }

    [ElementPriority(5)]
    public class GameBoy : IConfiguration
	{
		//todo Unity [CheckBoxControl("General", "Use Bootstrap ROM")]
		public bool UseBootstrap { get; set; }
		[IsBootstrapRomPath]
		//todo Unity [FileBrowserControl("General", "Bootstrap Path", "Game Boy Bootstrap ROM (*.gb;*.bin;*.zip)|*.gb;*.bin;*.zip")]
		public string BootstrapRom { get; set; }
		//todo Unity [DropDownControl("General", "Serial Device", typeof(ISerialDevice))]
		[JsonConverter(typeof(TypeNameJsonConverter), "Essgee.Emulation.ExtDevices.Nintendo")]
		public Type SerialDevice { get; set; }

		//todo Unity [DropDownControl("GB Camera", "Camera Source", typeof(GBCameraCartridge.ImageSources))]
		[JsonConverter(typeof(StringEnumConverter))]
		public GBCameraCartridge.ImageSources CameraSource { get; set; }
		//todo Unity [FileBrowserControl("GB Camera", "Camera Image", "Image Files (*.png;*.bmp)|*.png;*.bmp")]
		public string CameraImageFile { get; set; }

		//todo Unity [DropDownControl("Controls", "Up", typeof(Keys), Keys.F11)]
		[JsonConverter(typeof(StringEnumConverter))]
		public MotionKey ControlsUp { get; set; }
		//todo Unity [DropDownControl("Controls", "Down", typeof(Keys), Keys.F11)]
		[JsonConverter(typeof(StringEnumConverter))]
		public MotionKey ControlsDown { get; set; }
		//todo Unity [DropDownControl("Controls", "Left", typeof(Keys), Keys.F11)]
		[JsonConverter(typeof(StringEnumConverter))]
		public MotionKey ControlsLeft { get; set; }
		//todo Unity [DropDownControl("Controls", "Right", typeof(Keys), Keys.F11)]
		[JsonConverter(typeof(StringEnumConverter))]
		public MotionKey ControlsRight { get; set; }
		//todo Unity [DropDownControl("Controls", "A", typeof(Keys), Keys.F11)]
		[JsonConverter(typeof(StringEnumConverter))]
		public MotionKey ControlsA { get; set; }
		//todo Unity [DropDownControl("Controls", "B", typeof(Keys), Keys.F11)]
		[JsonConverter(typeof(StringEnumConverter))]
		public MotionKey ControlsB { get; set; }
		//todo Unity [DropDownControl("Controls", "Select", typeof(Keys), Keys.F11)]
		[JsonConverter(typeof(StringEnumConverter))]
		public MotionKey ControlsSelect { get; set; }
		//todo Unity [DropDownControl("Controls", "Start", typeof(Keys), Keys.F11)]
		[JsonConverter(typeof(StringEnumConverter))]
		public MotionKey ControlsStart { get; set; }

		public GameBoy()
		{
			UseBootstrap = false;
			BootstrapRom = string.Empty;

			SerialDevice = typeof(DummyDevice);
			CameraSource = GBCameraCartridge.ImageSources.Noise;
			CameraImageFile = string.Empty;

			ControlsUp = MotionKey.Up;
			ControlsDown = MotionKey.Down;
			ControlsLeft = MotionKey.Left;
			ControlsRight = MotionKey.Right;
			ControlsA = MotionKey.S;
			ControlsB = MotionKey.A;
			ControlsSelect = MotionKey.Space;
			ControlsStart = MotionKey.Enter;
		}
	}
}
