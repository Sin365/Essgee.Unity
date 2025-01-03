using Essgee.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Essgee.Emulation.Configuration
{
    //todo Unity [ElementPriority(3)]
    public class GameGear : IConfiguration
	{
		//todo Unity [DropDownControl("General", "Region", typeof(Region))]
		[JsonConverter(typeof(StringEnumConverter))]
		public Region Region { get; set; }

		//todo Unity [CheckBoxControl("General", "Use Bootstrap ROM")]
		public bool UseBootstrap { get; set; }
		[IsBootstrapRomPath]
		//todo Unity [FileBrowserControl("General", "Bootstrap Path", "Game Gear Bootstrap ROM (*.gg;*.zip)|*.gg;*.zip")]
		public string BootstrapRom { get; set; }

		//todo Unity [DropDownControl("Controls", "D-Pad Up", typeof(Keys), Keys.F11)]
		[JsonConverter(typeof(StringEnumConverter))]
		public MotionKey ControlsUp { get; set; }
		//todo Unity [DropDownControl("Controls", "D-Pad Down", typeof(Keys), Keys.F11)]
		[JsonConverter(typeof(StringEnumConverter))]
		public MotionKey ControlsDown { get; set; }
		//todo Unity [DropDownControl("Controls", "D-Pad Left", typeof(Keys), Keys.F11)]
		[JsonConverter(typeof(StringEnumConverter))]
		public MotionKey ControlsLeft { get; set; }
		//todo Unity [DropDownControl("Controls", "D-Pad Right", typeof(Keys), Keys.F11)]
		[JsonConverter(typeof(StringEnumConverter))]
		public MotionKey ControlsRight { get; set; }
		//todo Unity [DropDownControl("Controls", "Button 1", typeof(Keys), Keys.F11)]
		[JsonConverter(typeof(StringEnumConverter))]
		public MotionKey ControlsButton1 { get; set; }
		//todo Unity [DropDownControl("Controls", "Button 2", typeof(Keys), Keys.F11)]
		[JsonConverter(typeof(StringEnumConverter))]
		public MotionKey ControlsButton2 { get; set; }
		//todo Unity [DropDownControl("Controls", "Start", typeof(Keys), Keys.F11)]
		[JsonConverter(typeof(StringEnumConverter))]
		public MotionKey ControlsStart { get; set; }

		public bool AllowMemoryControl { get; set; }

		public GameGear()
		{
			BootstrapRom = string.Empty;

			Region = Region.Export;

			ControlsUp = MotionKey.Up;
			ControlsDown = MotionKey.Down;
			ControlsLeft = MotionKey.Left;
			ControlsRight = MotionKey.Right;
			ControlsButton1 = MotionKey.A;
			ControlsButton2 = MotionKey.S;
			ControlsStart = MotionKey.Return;

			AllowMemoryControl = true;
		}
	}
}
