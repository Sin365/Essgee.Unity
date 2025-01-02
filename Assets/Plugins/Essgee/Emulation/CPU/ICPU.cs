﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Essgee.Emulation.CPU
{
	interface ICPU
	{
		void Startup();
		void Shutdown();
		void Reset();
		int Step();

		void SetStackPointer(ushort value);
		void SetProgramCounter(ushort value);
	}
}
