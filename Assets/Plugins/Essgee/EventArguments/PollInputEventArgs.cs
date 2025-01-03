using Essgee.Utilities.XInput;
using System;
using System.Collections.Generic;

namespace Essgee.EventArguments
{
    public class PollInputEventArgs : EventArgs
	{
		public IEnumerable<MotionKey> Keyboard { get; set; }

		public MouseButtons MouseButtons { get; set; }
		public (int X, int Y) MousePosition { get; set; }

		public ControllerState ControllerState { get; set; }

		public PollInputEventArgs()
		{
			Keyboard = new List<MotionKey>();

			MouseButtons = MouseButtons.None;
			MousePosition = (0, 0);

			ControllerState = new ControllerState();
		}
	}
}
