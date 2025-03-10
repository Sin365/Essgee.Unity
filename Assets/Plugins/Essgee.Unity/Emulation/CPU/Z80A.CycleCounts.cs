﻿namespace Essgee.Emulation.CPU
{
    public partial class Z80A
    {
        public static class CycleCounts
        {
            public const int AdditionalJumpCond8Taken = 5;
            public const int AdditionalRetCondTaken = 6;
            public const int AdditionalCallCondTaken = 7;
            public const int AdditionalRepeatByteOps = 5;
            public const int AdditionalDDFDOps = 4;
            public const int AdditionalDDFDCBOps = 8;

            public static readonly int[] NoPrefix = new int[]
            {
                4,  10, 7,  6,  4,  4,  7,  4,      4,  11, 7,  6,  4,  4,  7,  4,  /* 0x00 - 0x0F */
				8,  10, 7,  6,  4,  4,  7,  4,      12, 11, 7,  6,  4,  4,  7,  4,  /* 0x10 - 0x1F */
				7,  10, 16, 6,  4,  4,  7,  4,      7,  11, 16, 6,  4,  4,  4,  4,  /* 0x20 - 0x2F */
				7,  10, 13, 6,  11, 11, 10, 4,      7,  11, 13, 6,  4,  4,  7,  4,  /* 0x30 - 0x3F */
				4,  4,  4,  4,  4,  4,  7,  4,      4,  4,  4,  4,  4,  4,  7,  4,  /* 0x40 - 0x4F */
				4,  4,  4,  4,  4,  4,  7,  4,      4,  4,  4,  4,  4,  4,  7,  4,  /* 0x50 - 0x5F */
				4,  4,  4,  4,  4,  4,  7,  4,      4,  4,  4,  4,  4,  4,  7,  4,  /* 0x60 - 0x6F */
				7,  7,  7,  7,  7,  7,  4,  7,      4,  4,  4,  4,  4,  4,  7,  4,  /* 0x70 - 0x7F */
				4,  4,  4,  4,  4,  4,  7,  4,      4,  4,  4,  4,  4,  4,  7,  4,  /* 0x80 - 0x8F */
				4,  4,  4,  4,  4,  4,  7,  4,      4,  4,  4,  4,  4,  4,  7,  4,  /* 0x90 - 0x9F */
				4,  4,  4,  4,  4,  4,  7,  4,      4,  4,  4,  4,  4,  4,  7,  4,  /* 0xA0 - 0xAF */
				4,  4,  4,  4,  4,  4,  7,  4,      4,  4,  4,  4,  4,  4,  7,  4,  /* 0xB0 - 0xBF */
				5,  10, 10, 10, 10, 11, 7,  11,     5,  10, 10, 0,  10, 17, 7,  11, /* 0xC0 - 0xCF */
				5,  10, 10, 11, 10, 11, 7,  11,     5,  4,  10, 11, 10, 0,  7,  11, /* 0xD0 - 0xDF */
				5,  10, 10, 19, 10, 11, 7,  11,     5,  4,  10, 4,  10, 0,  7,  11, /* 0xE0 - 0xEF */
				5,  10, 10, 4,  10, 11, 7,  11,     5,  6,  10, 4,  10, 0,  7,  11  /* 0xF0 - 0xFF */
			};

            public static readonly int[] PrefixED = new int[]
            {
                8,  8,  8,  8,  8,  8,  8,  8,      8,  8,  8,  8,  8,  8,  8,  8,  /* 0x00 - 0x0F */
				8,  8,  8,  8,  8,  8,  8,  8,      8,  8,  8,  8,  8,  8,  8,  8,  /* 0x10 - 0x1F */
				8,  8,  8,  8,  8,  8,  8,  8,      8,  8,  8,  8,  8,  8,  8,  8,  /* 0x20 - 0x2F */
				8,  8,  8,  8,  8,  8,  8,  8,      8,  8,  8,  8,  8,  8,  8,  8,  /* 0x30 - 0x3F */
				12, 12, 15, 20, 8,  14, 8,  9,      12, 12, 15, 20, 8,  14, 8,  9,  /* 0x40 - 0x4F */
				12, 12, 15, 20, 8,  14, 8,  9,      12, 12, 15, 20, 8,  14, 8,  9,  /* 0x50 - 0x5F */
				12, 12, 15, 20, 8,  14, 8,  18,     12, 12, 15, 20, 8,  14, 8,  18, /* 0x60 - 0x6F */
				12, 12, 15, 20, 8,  14, 8,  4,      12, 12, 15, 20, 8,  14, 8,  4,  /* 0x70 - 0x7F */
				8,  8,  8,  8,  8,  8,  8,  8,      8,  8,  8,  8,  8,  8,  8,  8,  /* 0x80 - 0x8F */
				8,  8,  8,  8,  8,  8,  8,  8,      8,  8,  8,  8,  8,  8,  8,  8,  /* 0x90 - 0x9F */
				16, 16, 16, 16, 8,  8,  8,  8,      16, 16, 16, 16, 8,  8,  8,  8,  /* 0xA0 - 0xAF */
				16, 16, 16, 16, 8,  8,  8,  8,      16, 16, 16, 16, 8,  8,  8,  8,  /* 0xB0 - 0xBF */
				8,  8,  8,  8,  8,  8,  8,  8,      8,  8,  8,  8,  8,  8,  8,  8,  /* 0xC0 - 0xCF */
				8,  8,  8,  8,  8,  8,  8,  8,      8,  8,  8,  8,  8,  8,  8,  8,  /* 0xD0 - 0xDF */
				8,  8,  8,  8,  8,  8,  8,  8,      8,  8,  8,  8,  8,  8,  8,  8,  /* 0xE0 - 0xEF */
				8,  8,  8,  8,  8,  8,  8,  8,      8,  8,  8,  8,  8,  8,  8,  8   /* 0xF0 - 0xFF */
			};

            public static readonly int[] PrefixCB = new int[]
            {
                8,  8,  8,  8,  8,  8,  15, 8,      8,  8,  8,  8,  8,  8,  15, 8,  /* 0x00 - 0x0F */
				8,  8,  8,  8,  8,  8,  15, 8,      8,  8,  8,  8,  8,  8,  15, 8,  /* 0x10 - 0x1F */
				8,  8,  8,  8,  8,  8,  15, 8,      8,  8,  8,  8,  8,  8,  15, 8,  /* 0x20 - 0x2F */
				8,  8,  8,  8,  8,  8,  15, 8,      8,  8,  8,  8,  8,  8,  15, 8,  /* 0x30 - 0x3F */
				8,  8,  8,  8,  8,  8,  12, 8,      8,  8,  8,  8,  8,  8,  12, 8,  /* 0x40 - 0x4F */
				8,  8,  8,  8,  8,  8,  12, 8,      8,  8,  8,  8,  8,  8,  12, 8,  /* 0x50 - 0x5F */
				8,  8,  8,  8,  8,  8,  12, 8,      8,  8,  8,  8,  8,  8,  12, 8,  /* 0x60 - 0x6F */
				8,  8,  8,  8,  8,  8,  12, 8,      8,  8,  8,  8,  8,  8,  12, 8,  /* 0x70 - 0x7F */
				8,  8,  8,  8,  8,  8,  15, 8,      8,  8,  8,  8,  8,  8,  15, 8,  /* 0x80 - 0x8F */
				8,  8,  8,  8,  8,  8,  15, 8,      8,  8,  8,  8,  8,  8,  15, 8,  /* 0x90 - 0x9F */
				8,  8,  8,  8,  8,  8,  15, 8,      8,  8,  8,  8,  8,  8,  15, 8,  /* 0xA0 - 0xAF */
				8,  8,  8,  8,  8,  8,  15, 8,      8,  8,  8,  8,  8,  8,  15, 8,  /* 0xB0 - 0xBF */
				8,  8,  8,  8,  8,  8,  15, 8,      8,  8,  8,  8,  8,  8,  15, 8,  /* 0xC0 - 0xCF */
				8,  8,  8,  8,  8,  8,  15, 8,      8,  8,  8,  8,  8,  8,  15, 8,  /* 0xD0 - 0xDF */
				8,  8,  8,  8,  8,  8,  15, 8,      8,  8,  8,  8,  8,  8,  15, 8,  /* 0xE0 - 0xEF */
				8,  8,  8,  8,  8,  8,  15, 8,      8,  8,  8,  8,  8,  8,  15, 8   /* 0xF0 - 0xFF */
			};

            public static readonly int[] PrefixDDFD = new int[]
            {
                0,  0,  0,  0,  0,  0,  0,  0,      0,  15, 0,  0,  0,  0,  0,  0,  /* 0x00 - 0x0F */
				0,  0,  0,  0,  0,  0,  0,  0,      0,  15, 0,  0,  0,  0,  0,  0,  /* 0x10 - 0x1F */
				0,  14, 20, 10, 0,  0,  0,  0,      0,  15, 20, 10, 0,  0,  0,  0,  /* 0x20 - 0x2F */
				0,  0,  0,  0,  23, 23, 19, 0,      0,  15, 0,  0,  0,  0,  0,  0,  /* 0x30 - 0x3F */
				0,  0,  0,  0,  0,  0,  19, 0,      0,  0,  0,  0,  0,  0,  19, 0,  /* 0x40 - 0x4F */
				0,  0,  0,  0,  0,  0,  19, 0,      0,  0,  0,  0,  0,  0,  19, 0,  /* 0x50 - 0x5F */
				0,  0,  0,  0,  0,  0,  19, 0,      0,  0,  0,  0,  0,  0,  19, 0,  /* 0x60 - 0x6F */
				19, 19, 19, 19, 19, 19, 0,  19,     0,  0,  0,  0,  0,  0,  19, 0,  /* 0x70 - 0x7F */
				0,  0,  0,  0,  0,  0,  19, 0,      0,  0,  0,  0,  0,  0,  19, 0,  /* 0x80 - 0x8F */
				0,  0,  0,  0,  0,  0,  19, 0,      0,  0,  0,  0,  0,  0,  19, 0,  /* 0x90 - 0x9F */
				0,  0,  0,  0,  0,  0,  19, 0,      0,  0,  0,  0,  0,  0,  19, 0,  /* 0xA0 - 0xAF */
				0,  0,  0,  0,  0,  0,  19, 0,      0,  0,  0,  0,  0,  0,  19, 0,  /* 0xB0 - 0xBF */
				0,  0,  0,  0,  0,  0,  0,  0,      0,  0,  0,  0,  0,  0,  0,  0,  /* 0xC0 - 0xCF */
				0,  0,  0,  0,  0,  0,  0,  0,      0,  0,  0,  0,  0,  0,  0,  0,  /* 0xD0 - 0xDF */
				0,  14, 0,  23, 0,  15, 0,  0,      0,  8,  0,  0,  0,  0,  0,  0,  /* 0xE0 - 0xEF */
				0,  0,  0,  0,  0,  0,  0,  0,      0,  10, 0,  0,  0,  0,  0,  0   /* 0xF0 - 0xFF */
			};
        }
    }
}
