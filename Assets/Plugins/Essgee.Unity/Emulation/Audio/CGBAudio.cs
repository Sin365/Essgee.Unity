﻿namespace Essgee.Emulation.Audio
{
    public partial class CGBAudio : DMGAudio, IAudio
    {
        public CGBAudio()
        {
            //channelSampleBuffer = new List<short>[numChannels];
            //for (int i = 0; i < numChannels; i++) channelSampleBuffer[i] = new List<short>();
            //mixedSampleBuffer = new List<short>();

            //改为二维数组
            channelSampleBuffer_Init(numChannels, 1470);
            mixedSampleBuffer_set = new short[1470];

            channel1 = new Square(true);
            channel2 = new Square(false);
            channel3 = new CGBWave();
            channel4 = new Noise();

            samplesPerFrame = cyclesPerFrame = cyclesPerSample = -1;
        }

        #region AxiState

        public void LoadAxiStatus(AxiEssgssStatusData data)
        {
            base.LoadAxiStatus(data);
        }

        public AxiEssgssStatusData SaveAxiStatus()
        {
            AxiEssgssStatusData data = base.SaveAxiStatus();
            return data;
        }
        #endregion
    }
}
