﻿using Essgee.Utilities;
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
		public Keys ControlsUp { get; set; }
		//todo Unity [DropDownControl("Controls", "D-Pad Down", typeof(Keys), Keys.F11)]
		[JsonConverter(typeof(StringEnumConverter))]
		public Keys ControlsDown { get; set; }
		//todo Unity [DropDownControl("Controls", "D-Pad Left", typeof(Keys), Keys.F11)]
		[JsonConverter(typeof(StringEnumConverter))]
		public Keys ControlsLeft { get; set; }
		//todo Unity [DropDownControl("Controls", "D-Pad Right", typeof(Keys), Keys.F11)]
		[JsonConverter(typeof(StringEnumConverter))]
		public Keys ControlsRight { get; set; }
		//todo Unity [DropDownControl("Controls", "Button 1", typeof(Keys), Keys.F11)]
		[JsonConverter(typeof(StringEnumConverter))]
		public Keys ControlsButton1 { get; set; }
		//todo Unity [DropDownControl("Controls", "Button 2", typeof(Keys), Keys.F11)]
		[JsonConverter(typeof(StringEnumConverter))]
		public Keys ControlsButton2 { get; set; }
		//todo Unity [DropDownControl("Controls", "Start", typeof(Keys), Keys.F11)]
		[JsonConverter(typeof(StringEnumConverter))]
		public Keys ControlsStart { get; set; }

		public bool AllowMemoryControl { get; set; }

		public GameGear()
		{
			BootstrapRom = string.Empty;

			Region = Region.Export;

			ControlsUp = Keys.Up;
			ControlsDown = Keys.Down;
			ControlsLeft = Keys.Left;
			ControlsRight = Keys.Right;
			ControlsButton1 = Keys.A;
			ControlsButton2 = Keys.S;
			ControlsStart = Keys.Return;

			AllowMemoryControl = true;
		}
	}
}
