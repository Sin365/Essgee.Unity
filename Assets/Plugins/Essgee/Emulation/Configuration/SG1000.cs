using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Essgee.Emulation.Configuration
{
    //todo Unity [ElementPriority(0)]
    public class SG1000 : IConfiguration
	{
		//todo Unity [DropDownControl("General", "TV Standard", typeof(TVStandard))]
		[JsonConverter(typeof(StringEnumConverter))]
		public TVStandard TVStandard { get; set; }

		//todo Unity [DropDownControl("General", "Pause Button", typeof(Keys), Keys.F11)]
		[JsonConverter(typeof(StringEnumConverter))]
		public MotionKey InputPause { get; set; }

		//todo Unity [DropDownControl("Controller Port 1", "D-Pad Up", typeof(Keys), Keys.F11)]
		[JsonConverter(typeof(StringEnumConverter))]
		public MotionKey Joypad1Up { get; set; }
		//todo Unity [DropDownControl("Controller Port 1", "D-Pad Down", typeof(Keys), Keys.F11)]
		[JsonConverter(typeof(StringEnumConverter))]
		public MotionKey Joypad1Down { get; set; }
		//todo Unity [DropDownControl("Controller Port 1", "D-Pad Left", typeof(Keys), Keys.F11)]
		[JsonConverter(typeof(StringEnumConverter))]
		public MotionKey Joypad1Left { get; set; }
		//todo Unity [DropDownControl("Controller Port 1", "D-Pad Right", typeof(Keys), Keys.F11)]
		[JsonConverter(typeof(StringEnumConverter))]
		public MotionKey Joypad1Right { get; set; }
		//todo Unity [DropDownControl("Controller Port 1", "Button 1", typeof(Keys), Keys.F11)]
		[JsonConverter(typeof(StringEnumConverter))]
		public MotionKey Joypad1Button1 { get; set; }
		//todo Unity [DropDownControl("Controller Port 1", "Button 2", typeof(Keys), Keys.F11)]
		[JsonConverter(typeof(StringEnumConverter))]
		public MotionKey Joypad1Button2 { get; set; }

		//todo Unity [DropDownControl("Controller Port 2", "D-Pad Up", typeof(Keys), Keys.F11)]
		[JsonConverter(typeof(StringEnumConverter))]
		public MotionKey Joypad2Up { get; set; }
		//todo Unity [DropDownControl("Controller Port 2", "D-Pad Down", typeof(Keys), Keys.F11)]
		[JsonConverter(typeof(StringEnumConverter))]
		public MotionKey Joypad2Down { get; set; }
		//todo Unity [DropDownControl("Controller Port 2", "D-Pad Left", typeof(Keys), Keys.F11)]
		[JsonConverter(typeof(StringEnumConverter))]
		public MotionKey Joypad2Left { get; set; }
		//todo Unity [DropDownControl("Controller Port 2", "D-Pad Right", typeof(Keys), Keys.F11)]
		[JsonConverter(typeof(StringEnumConverter))]
		public MotionKey Joypad2Right { get; set; }
		//todo Unity [DropDownControl("Controller Port 2", "Button 1", typeof(Keys), Keys.F11)]
		[JsonConverter(typeof(StringEnumConverter))]
		public MotionKey Joypad2Button1 { get; set; }
		//todo Unity [DropDownControl("Controller Port 2", "Button 2", typeof(Keys), Keys.F11)]
		[JsonConverter(typeof(StringEnumConverter))]
		public MotionKey Joypad2Button2 { get; set; }

		public SG1000()
		{
			TVStandard = TVStandard.NTSC;

			InputPause = MotionKey.Space;

			Joypad1Up = MotionKey.Up;
			Joypad1Down = MotionKey.Down;
			Joypad1Left = MotionKey.Left;
			Joypad1Right = MotionKey.Right;
			Joypad1Button1 = MotionKey.A;
			Joypad1Button2 = MotionKey.S;

			Joypad2Up = MotionKey.NumPad8;
			Joypad2Down = MotionKey.NumPad2;
			Joypad2Left = MotionKey.NumPad4;
			Joypad2Right = MotionKey.NumPad6;
			Joypad2Button1 = MotionKey.NumPad1;
			Joypad2Button2 = MotionKey.NumPad3;
		}
	}
}
