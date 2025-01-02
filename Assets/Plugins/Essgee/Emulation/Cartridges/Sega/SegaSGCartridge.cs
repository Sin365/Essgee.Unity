﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Essgee.Utilities;

namespace Essgee.Emulation.Cartridges.Sega
{
	public class SegaSGCartridge : ICartridge
	{
		byte[] romData;

		[StateRequired]
		byte[] ramData;

		[StateRequired]
		readonly int romMask, ramMask;

		public SegaSGCartridge(int romSize, int ramSize)
		{
			romData = new byte[romSize];
			ramData = new byte[ramSize];

			romMask = 1;
			while (romMask < romSize) romMask <<= 1;
			romMask -= 1;

			ramMask = (ramSize - 1);
		}

		public void LoadRom(byte[] data)
		{
			Buffer.BlockCopy(data, 0, romData, 0, Math.Min(data.Length, romData.Length));
		}

		public void LoadRam(byte[] data)
		{
			Buffer.BlockCopy(data, 0, ramData, 0, Math.Min(data.Length, ramData.Length));
		}

		public byte[] GetRomData()
		{
			return romData;
		}

		public byte[] GetRamData()
		{
			return ramData;
		}

		public bool IsRamSaveNeeded()
		{
			return false;
		}

		public ushort GetLowerBound()
		{
			return 0x0000;
		}

		public ushort GetUpperBound()
		{
			return (ushort)((romData.Length + ramData.Length) - 1);
		}

		public void Step(int clockCyclesInStep)
		{
			/* Nothing to do */
		}

		public byte Read(ushort address)
		{
			if (ramData.Length > 0)
			{
				if (address < (romMask + 1))
					return romData[address & romMask];
				else
					return ramData[address & ramMask];
			}
			else
			{
				return romData[address & romMask];
			}
		}

		public void Write(ushort address, byte value)
		{
			if (ramData.Length > 0 && address >= (romMask + 1))
				ramData[address & ramMask] = value;
		}
	}
}
