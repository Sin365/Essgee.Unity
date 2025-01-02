﻿using System;
using System.IO;

namespace Essgee.Utilities
{
	public static class Crc32
	{
		static readonly uint[] crcTable;
		static readonly uint crcPolynomial = 0xEDB88320;
		static readonly uint crcSeed = 0xFFFFFFFF;

		static Crc32()
		{
			crcTable = new uint[256];

			for (int i = 0; i < 256; i++)
			{
				uint entry = (uint)i;
				for (int j = 0; j < 8; j++)
				{
					if ((entry & 0x00000001) == 0x00000001)
						entry = (entry >> 1) ^ crcPolynomial;
					else
						entry = (entry >> 1);
				}
				crcTable[i] = entry;
			}
		}

		private static void VerifyStartAndLength(int dataLength, int segmentStart, int segmentLength)
		{
			if (segmentStart >= dataLength) throw new Crc32Exception("Segment start offset is greater than total length");
			if (segmentLength > dataLength) throw new Crc32Exception("Segment length is greater than total length");
			if ((segmentStart + segmentLength) > dataLength) throw new Crc32Exception("Segment end offset is greater than total length");
		}

		public static uint Calculate(FileInfo fileInfo)
		{
			return Calculate(fileInfo, 0, (int)fileInfo.Length);
		}

		public static uint Calculate(FileInfo fileInfo, int start, int length)
		{
			VerifyStartAndLength((int)fileInfo.Length, start, length);

			using (FileStream file = fileInfo.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
			{
				return Calculate(file, start, length);
			}
		}

		public static uint Calculate(Stream stream)
		{
			return Calculate(stream, 0, (int)stream.Length);
		}

		public static uint Calculate(Stream stream, int start, int length)
		{
			VerifyStartAndLength((int)stream.Length, start, length);

			uint crc = 0;

			var lastStreamPosition = stream.Position;

			byte[] data = new byte[length];
			stream.Position = start;
			stream.Read(data, 0, length);
			crc = Calculate(data, 0, data.Length);
			stream.Position = lastStreamPosition;

			return crc;
		}

		public static uint Calculate(byte[] data)
		{
			return Calculate(data, 0, data.Length);
		}

		public static uint Calculate(byte[] data, int start, int length)
		{
			VerifyStartAndLength(data.Length, start, length);

			uint crc = crcSeed;
			for (int i = start; i < (start + length); i++)
				crc = ((crc >> 8) ^ crcTable[data[i] ^ (crc & 0x000000FF)]);
			return ~crc;
		}
	}

	[Serializable]
	public class Crc32Exception : Exception
	{
		public Crc32Exception() : base() { }
		public Crc32Exception(string message) : base(message) { }
		public Crc32Exception(string message, Exception innerException) : base(message, innerException) { }
		public Crc32Exception(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
