﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Essgee.Exceptions;
using Essgee.Utilities;

namespace Essgee.Emulation.Cartridges.Sega
{
	public class CodemastersCartridge : ICartridge
	{
		byte[] romData;

		[StateRequired]
		byte[] ramData;

		[StateRequired]
		readonly byte[] pagingRegisters;
		[StateRequired]
		readonly byte bankMask;

		[StateRequired]
		bool isRamEnabled;

		public CodemastersCartridge(int romSize, int ramSize)
		{
			pagingRegisters = new byte[3];
			pagingRegisters[0] = 0x00;
			pagingRegisters[1] = 0x01;
			pagingRegisters[2] = 0x02;

			romData = new byte[romSize];
			ramData = new byte[ramSize];

			bankMask = (byte)((romData.Length >> 14) - 1);

			isRamEnabled = false;
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
			return 0xBFFF;
		}

		public void Step(int clockCyclesInStep)
		{
			/* Nothing to do */
		}

		public byte Read(ushort address)
		{
			switch (address & 0xC000)
			{
				case 0x0000:
					return romData[((pagingRegisters[0] << 14) | (address & 0x3FFF))];

				case 0x4000:
					return romData[((pagingRegisters[1] << 14) | (address & 0x3FFF))];

				case 0x8000:
					if (isRamEnabled && (address >= 0xA000 && address <= 0xBFFF))
						return ramData[address & 0x1FFF];
					else
						return romData[((pagingRegisters[2] << 14) | (address & 0x3FFF))];

				default:
					throw new EmulationException(string.Format("Codemasters mapper: Cannot read from cartridge address 0x{0:X4}", address));
			}
		}

		public void Write(ushort address, byte value)
		{
			switch (address)
			{
				case 0x0000:
					pagingRegisters[0] = (byte)(value & bankMask);
					break;

				case 0x4000:
					pagingRegisters[1] = (byte)(value & bankMask);
					isRamEnabled = ((value & 0x80) == 0x80);
					break;

				case 0x8000:
					pagingRegisters[2] = (byte)(value & bankMask);
					break;
			}

			if (isRamEnabled && ((address & 0xF000) == 0xA000 || (address & 0xF000) == 0xB000))
				ramData[address & 0x1FFF] = value;
		}
	}
}
