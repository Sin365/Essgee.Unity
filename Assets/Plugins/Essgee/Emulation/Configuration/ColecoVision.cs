using Essgee.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Essgee.Emulation.Configuration
{
    ////todo Unity [ElementPriorityAttribute(4)]
	public class ColecoVision : IConfiguration
	{
		[IsBootstrapRomPath]
		//todo Unity [FileBrowserControl("General", "BIOS Path", "ColecoVision BIOS ROM (*.col;*.zip)|*.col;*.zip")]
		public string BiosRom { get; set; }

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
		//todo Unity [DropDownControl("Controls", "Left Button", typeof(Keys), Keys.F11)]
		[JsonConverter(typeof(StringEnumConverter))]
		public MotionKey ControlsButtonLeft { get; set; }
		//todo Unity [DropDownControl("Controls", "Right Button", typeof(Keys), Keys.F11)]
		[JsonConverter(typeof(StringEnumConverter))]
		public MotionKey ControlsButtonRight { get; set; }

		//todo Unity [DropDownControl("Controls", "Keypad 1", typeof(Keys), Keys.F11)]
		[JsonConverter(typeof(StringEnumConverter))]
		public MotionKey ControlsKeypad1 { get; set; }
		//todo Unity [DropDownControl("Controls", "Keypad 2", typeof(Keys), Keys.F11)]
		[JsonConverter(typeof(StringEnumConverter))]
		public MotionKey ControlsKeypad2 { get; set; }
		//todo Unity [DropDownControl("Controls", "Keypad 3", typeof(Keys), Keys.F11)]
		[JsonConverter(typeof(StringEnumConverter))]
		public MotionKey ControlsKeypad3 { get; set; }
		//todo Unity [DropDownControl("Controls", "Keypad 4", typeof(Keys), Keys.F11)]
		[JsonConverter(typeof(StringEnumConverter))]
		public MotionKey ControlsKeypad4 { get; set; }
		//todo Unity [DropDownControl("Controls", "Keypad 5", typeof(Keys), Keys.F11)]
		[JsonConverter(typeof(StringEnumConverter))]
		public MotionKey ControlsKeypad5 { get; set; }
		//todo Unity [DropDownControl("Controls", "Keypad 6", typeof(Keys), Keys.F11)]
		[JsonConverter(typeof(StringEnumConverter))]
		public MotionKey ControlsKeypad6 { get; set; }
		//todo Unity [DropDownControl("Controls", "Keypad 7", typeof(Keys), Keys.F11)]
		[JsonConverter(typeof(StringEnumConverter))]
		public MotionKey ControlsKeypad7 { get; set; }
		//todo Unity [DropDownControl("Controls", "Keypad 8", typeof(Keys), Keys.F11)]
		[JsonConverter(typeof(StringEnumConverter))]
		public MotionKey ControlsKeypad8 { get; set; }
		//todo Unity [DropDownControl("Controls", "Keypad 9", typeof(Keys), Keys.F11)]
		[JsonConverter(typeof(StringEnumConverter))]
		public MotionKey ControlsKeypad9 { get; set; }
		//todo Unity [DropDownControl("Controls", "Keypad 0", typeof(Keys), Keys.F11)]
		[JsonConverter(typeof(StringEnumConverter))]
		public MotionKey ControlsKeypad0 { get; set; }
		//todo Unity [DropDownControl("Controls", "Keypad *", typeof(Keys), Keys.F11)]
		[JsonConverter(typeof(StringEnumConverter))]
		public MotionKey ControlsKeypadStar { get; set; }
		//todo Unity [DropDownControl("Controls", "Keypad #", typeof(Keys), Keys.F11)]
		[JsonConverter(typeof(StringEnumConverter))]
		public MotionKey ControlsKeypadNumberSign { get; set; }

		public ColecoVision()
		{
			BiosRom = string.Empty;

			ControlsUp = MotionKey.Up;
			ControlsDown = MotionKey.Down;
			ControlsLeft = MotionKey.Left;
			ControlsRight = MotionKey.Right;
			ControlsButtonLeft = MotionKey.A;
			ControlsButtonRight = MotionKey.S;

			ControlsKeypad1 = MotionKey.NumPad1;
			ControlsKeypad2 = MotionKey.NumPad2;
			ControlsKeypad3 = MotionKey.NumPad3;
			ControlsKeypad4 = MotionKey.NumPad4;
			ControlsKeypad5 = MotionKey.NumPad5;
			ControlsKeypad6 = MotionKey.NumPad6;
			ControlsKeypad7 = MotionKey.NumPad7;
			ControlsKeypad8 = MotionKey.NumPad8;
			ControlsKeypad9 = MotionKey.NumPad9;
			ControlsKeypad0 = MotionKey.NumPad0;
			ControlsKeypadStar = MotionKey.Multiply;
			ControlsKeypadNumberSign = MotionKey.Divide;
		}
	}
}
