﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Essgee.EventArguments;

namespace Essgee.Emulation.Audio
{
	interface IAudio
	{
		event EventHandler<EnqueueSamplesEventArgs> EnqueueSamples;
		void OnEnqueueSamples(EnqueueSamplesEventArgs e);

		(string Name, string Description)[] RuntimeOptions { get; }

		object GetRuntimeOption(string name);
		void SetRuntimeOption(string name, object value);

		void Startup();
		void Shutdown();
		void Reset();
		void Step(int clockCyclesInStep);

		void SetSampleRate(int rate);
		void SetOutputChannels(int channels);
		void SetClockRate(double clock);
		void SetRefreshRate(double refresh);
	}
}
