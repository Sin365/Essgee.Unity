using System.Collections.Generic;

namespace Essgee.Emulation.Audio
{
    public partial class CGBAudio : DMGAudio, IAudio
	{
		public CGBAudio()
		{
			channelSampleBuffer = new List<short>[numChannels];
			for (int i = 0; i < numChannels; i++) channelSampleBuffer[i] = new List<short>();

			mixedSampleBuffer = new List<short>();

			channel1 = new Square(true);
			channel2 = new Square(false);
			channel3 = new CGBWave();
			channel4 = new Noise();

			samplesPerFrame = cyclesPerFrame = cyclesPerSample = -1;
		}
	}
}
