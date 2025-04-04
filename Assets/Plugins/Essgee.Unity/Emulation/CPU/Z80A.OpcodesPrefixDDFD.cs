﻿namespace Essgee.Emulation.CPU
{
    public partial class Z80A
    {
        static DDFDOpcodeDelegate[] opcodesPrefixDDFD = new DDFDOpcodeDelegate[]
        {
			/* 0x00 */
			new DDFDOpcodeDelegate((Z80A c, ref Register r) => { /* NOP */ }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadRegisterImmediate16(ref c.bc.Word); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadMemory8(c.bc.Word, c.af.High); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Increment16(ref c.bc.Word); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Increment8(ref c.bc.High); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Decrement8(ref c.bc.High); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadRegisterImmediate8(ref c.bc.High, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.RotateLeftAccumulatorCircular(); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.ExchangeRegisters16(ref c.af, ref c.af_); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Add16(ref r, c.bc.Word, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadRegisterFromMemory8(ref c.af.High, c.bc.Word, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Decrement16(ref c.bc.Word); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Increment8(ref c.bc.Low); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Decrement8(ref c.bc.Low); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadRegisterImmediate8(ref c.bc.Low, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.RotateRightAccumulatorCircular(); }),
			/* 0x10 */
			new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.DecrementJumpNonZero(); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadRegisterImmediate16(ref c.de.Word); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadMemory8(c.de.Word, c.af.High); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Increment16(ref c.de.Word); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Increment8(ref c.de.High); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Decrement8(ref c.de.High); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadRegisterImmediate8(ref c.de.High, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.RotateLeftAccumulator(); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Jump8(); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Add16(ref r, c.de.Word, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadRegisterFromMemory8(ref c.af.High, c.de.Word, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Decrement16(ref c.de.Word); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Increment8(ref c.de.Low); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Decrement8(ref c.de.Low); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadRegisterImmediate8(ref c.de.Low, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.RotateRightAccumulator(); }),
			/* 0x20 */
			new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.JumpConditional8(!c.IsFlagSet(Flags.Zero)); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadRegisterImmediate16(ref r.Word); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadMemory16(c.ReadMemory16(c.pc), r.Word); c.pc += 2; }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Increment16(ref r.Word); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Increment8(ref r.High); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Decrement8(ref r.High); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { r.High = c.ReadMemory8(c.pc++); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.DecimalAdjustAccumulator(); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.JumpConditional8(c.IsFlagSet(Flags.Zero)); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Add16(ref r, r.Word, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadRegister16(ref r.Word, c.ReadMemory16(c.ReadMemory16(c.pc))); c.pc += 2; }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Decrement16(ref r.Word); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Increment8(ref r.Low); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Decrement8(ref r.Low); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { r.Low = c.ReadMemory8(c.pc++); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.af.High ^= 0xFF; c.SetFlag(Flags.Subtract | Flags.HalfCarry); }),
			/* 0x30 */
			new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.JumpConditional8(!c.IsFlagSet(Flags.Carry)); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadRegisterImmediate16(ref c.sp); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadMemory8(c.ReadMemory16(c.pc), c.af.High); c.pc += 2; }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Increment16(ref c.sp); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.IncrementMemory8(c.CalculateIXIYAddress(r)); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.DecrementMemory8(c.CalculateIXIYAddress(r)); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadMemory8(c.CalculateIXIYAddress(r), c.ReadMemory8(c.pc++)); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.SetFlag(Flags.Carry); c.ClearFlag(Flags.Subtract | Flags.HalfCarry); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.JumpConditional8(c.IsFlagSet(Flags.Carry)); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Add16(ref r, c.sp, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadRegisterFromMemory8(ref c.af.High, c.ReadMemory16(c.pc), false); c.pc += 2; }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Decrement16(ref c.sp); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Increment8(ref c.af.High); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Decrement8(ref c.af.High); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadRegisterImmediate8(ref c.af.High, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.ClearFlag(Flags.Subtract); c.SetClearFlagConditional(Flags.Carry, !c.IsFlagSet(Flags.Carry)); }),
			/* 0x40 */
			new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadRegister8(ref c.bc.High, c.bc.High, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadRegister8(ref c.bc.High, c.bc.Low, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadRegister8(ref c.bc.High, c.de.High, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadRegister8(ref c.bc.High, c.de.Low, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadRegister8(ref c.bc.High, r.High, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadRegister8(ref c.bc.High, r.Low, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.bc.High = c.ReadMemory8(c.CalculateIXIYAddress(r)); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadRegister8(ref c.bc.High, c.af.High, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadRegister8(ref c.bc.Low, c.bc.High, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadRegister8(ref c.bc.Low, c.bc.Low, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadRegister8(ref c.bc.Low, c.de.High, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadRegister8(ref c.bc.Low, c.de.Low, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadRegister8(ref c.bc.Low, r.High, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadRegister8(ref c.bc.Low, r.Low, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.bc.Low = c.ReadMemory8(c.CalculateIXIYAddress(r)); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadRegister8(ref c.bc.Low, c.af.High, false); }),
			/* 0x50 */
			new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadRegister8(ref c.de.High, c.bc.High, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadRegister8(ref c.de.High, c.bc.Low, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadRegister8(ref c.de.High, c.de.High, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadRegister8(ref c.de.High, c.de.Low, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadRegister8(ref c.de.High, r.High, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadRegister8(ref c.de.High, r.Low, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.de.High = c.ReadMemory8(c.CalculateIXIYAddress(r)); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadRegister8(ref c.de.High, c.af.High, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadRegister8(ref c.de.Low, c.bc.High, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadRegister8(ref c.de.Low, c.bc.Low, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadRegister8(ref c.de.Low, c.de.High, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadRegister8(ref c.de.Low, c.de.Low, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadRegister8(ref c.de.Low, r.High, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadRegister8(ref c.de.Low, r.Low, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.de.Low = c.ReadMemory8(c.CalculateIXIYAddress(r)); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadRegister8(ref c.de.Low, c.af.High, false); }),
			/* 0x60 */
			new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadRegister8(ref r.High, c.bc.High, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadRegister8(ref r.High, c.bc.Low, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadRegister8(ref r.High, c.de.High, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadRegister8(ref r.High, c.de.Low, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadRegister8(ref r.High, r.High, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadRegister8(ref r.High, r.Low, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.hl.High = c.ReadMemory8(c.CalculateIXIYAddress(r)); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadRegister8(ref r.High, c.af.High, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadRegister8(ref r.Low, c.bc.High, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadRegister8(ref r.Low, c.bc.Low, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadRegister8(ref r.Low, c.de.High, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadRegister8(ref r.Low, c.de.Low, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadRegister8(ref r.Low, r.High, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadRegister8(ref r.Low, r.Low, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.hl.Low = c.ReadMemory8(c.CalculateIXIYAddress(r)); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadRegister8(ref r.Low, c.af.High, false); }),
			/* 0x70 */
			new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadMemory8(c.CalculateIXIYAddress(r), c.bc.High); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadMemory8(c.CalculateIXIYAddress(r), c.bc.Low); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadMemory8(c.CalculateIXIYAddress(r), c.de.High); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadMemory8(c.CalculateIXIYAddress(r), c.de.Low); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadMemory8(c.CalculateIXIYAddress(r), c.hl.High); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadMemory8(c.CalculateIXIYAddress(r), c.hl.Low); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.EnterHaltState(); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadMemory8(c.CalculateIXIYAddress(r), c.af.High); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadRegister8(ref c.af.High, c.bc.High, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadRegister8(ref c.af.High, c.bc.Low, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadRegister8(ref c.af.High, c.de.High, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadRegister8(ref c.af.High, c.de.Low, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadRegister8(ref c.af.High, r.High, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadRegister8(ref c.af.High, r.Low, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.af.High = c.ReadMemory8(c.CalculateIXIYAddress(r)); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.LoadRegister8(ref c.af.High, c.af.High, false); }),
			/* 0x80 */
			new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Add8(c.bc.High, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Add8(c.bc.Low, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Add8(c.de.High, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Add8(c.de.Low, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Add8(r.High, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Add8(r.Low, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Add8(c.ReadMemory8(c.CalculateIXIYAddress(r)), false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Add8(c.af.High, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Add8(c.bc.High, true); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Add8(c.bc.Low, true); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Add8(c.de.High, true); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Add8(c.de.Low, true); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Add8(r.High, true); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Add8(r.Low, true); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Add8(c.ReadMemory8(c.CalculateIXIYAddress(r)), true); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Add8(c.af.High, true); }),
			/* 0x90 */
			new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Subtract8(c.bc.High, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Subtract8(c.bc.Low, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Subtract8(c.de.High, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Subtract8(c.de.Low, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Subtract8(r.High, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Subtract8(r.Low, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Subtract8(c.ReadMemory8(c.CalculateIXIYAddress(r)), false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Subtract8(c.af.High, false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Subtract8(c.bc.High, true); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Subtract8(c.bc.Low, true); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Subtract8(c.de.High, true); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Subtract8(c.de.Low, true); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Subtract8(r.High, true); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Subtract8(r.Low, true); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Subtract8(c.ReadMemory8(c.CalculateIXIYAddress(r)), true); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Subtract8(c.af.High, true); }),
			/* 0xA0 */
			new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.And8(c.bc.High); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.And8(c.bc.Low); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.And8(c.de.High); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.And8(c.de.Low); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.And8(r.High); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.And8(r.Low); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.And8(c.ReadMemory8(c.CalculateIXIYAddress(r))); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.And8(c.af.High); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Xor8(c.bc.High); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Xor8(c.bc.Low); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Xor8(c.de.High); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Xor8(c.de.Low); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Xor8(r.High); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Xor8(r.Low); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Xor8(c.ReadMemory8(c.CalculateIXIYAddress(r))); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Xor8(c.af.High); }),
			/* 0xB0 */
			new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Or8(c.bc.High); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Or8(c.bc.Low); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Or8(c.de.High); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Or8(c.de.Low); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Or8(r.High); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Or8(r.Low); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Or8(c.ReadMemory8(c.CalculateIXIYAddress(r))); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Or8(c.af.High); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Cp8(c.bc.High); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Cp8(c.bc.Low); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Cp8(c.de.High); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Cp8(c.de.Low); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Cp8(r.High); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Cp8(r.Low); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Cp8(c.ReadMemory8(c.CalculateIXIYAddress(r))); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Cp8(c.af.High); }),
			/* 0xC0 */
			new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.ReturnConditional(!c.IsFlagSet(Flags.Zero)); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Pop(ref c.bc); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.JumpConditional16(!c.IsFlagSet(Flags.Zero)); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.JumpConditional16(true); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.CallConditional16(!c.IsFlagSet(Flags.Zero)); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Push(c.bc); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Add8(c.ReadMemory8(c.pc++), false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Restart(0x0000); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.ReturnConditional(c.IsFlagSet(Flags.Zero)); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Return(); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.JumpConditional16(c.IsFlagSet(Flags.Zero)); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.ExecuteOpDDFDCB(c.ReadMemory8((ushort)(c.pc + 1)), ref r); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.CallConditional16(c.IsFlagSet(Flags.Zero)); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Call16(); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Add8(c.ReadMemory8(c.pc++), true); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Restart(0x0008); }),
			/* 0xD0 */
			new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.ReturnConditional(!c.IsFlagSet(Flags.Carry)); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Pop(ref c.de); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.JumpConditional16(!c.IsFlagSet(Flags.Carry)); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.WritePort(c.ReadMemory8(c.pc++), c.af.High); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.CallConditional16(!c.IsFlagSet(Flags.Carry)); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Push(c.de); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Subtract8(c.ReadMemory8(c.pc++), false); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Restart(0x0010); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.ReturnConditional(c.IsFlagSet(Flags.Carry)); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.ExchangeRegisters16(ref c.bc, ref c.bc_); c.ExchangeRegisters16(ref c.de, ref c.de_); c.ExchangeRegisters16(ref c.hl, ref c.hl_); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.JumpConditional16(c.IsFlagSet(Flags.Carry)); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.af.High = c.ReadPort(c.ReadMemory8(c.pc++)); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.CallConditional16(c.IsFlagSet(Flags.Carry)); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { /* DD - treat as NOP */ }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Subtract8(c.ReadMemory8(c.pc++), true); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Restart(0x0018); }),
			/* 0xE0 */
			new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.ReturnConditional(!c.IsFlagSet(Flags.ParityOrOverflow)); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Pop(ref r); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.JumpConditional16(!c.IsFlagSet(Flags.ParityOrOverflow)); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.ExchangeStackRegister16(ref r); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.CallConditional16(!c.IsFlagSet(Flags.ParityOrOverflow)); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Push(r); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.And8(c.ReadMemory8(c.pc++)); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Restart(0x0020); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.ReturnConditional(c.IsFlagSet(Flags.ParityOrOverflow)); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.pc = r.Word; }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.JumpConditional16(c.IsFlagSet(Flags.ParityOrOverflow)); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.ExchangeRegisters16(ref c.de, ref c.hl); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.CallConditional16(c.IsFlagSet(Flags.ParityOrOverflow)); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { /* ED - treat as NOP */ }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Xor8(c.ReadMemory8(c.pc++)); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Restart(0x0028); }),
			/* 0xF0 */
			new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.ReturnConditional(!c.IsFlagSet(Flags.Sign)); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Pop(ref c.af); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.JumpConditional16(!c.IsFlagSet(Flags.Sign)); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.iff1 = c.iff2 = false; }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.CallConditional16(!c.IsFlagSet(Flags.Sign)); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Push(c.af); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Or8(c.ReadMemory8(c.pc++)); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Restart(0x0030); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.ReturnConditional(c.IsFlagSet(Flags.Sign)); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.sp = r.Word; }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.JumpConditional16(c.IsFlagSet(Flags.Sign)); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.eiDelay = true; }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.CallConditional16(c.IsFlagSet(Flags.Sign)); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { /* FD - treat as NOP */ }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Cp8(c.ReadMemory8(c.pc++)); }),
            new DDFDOpcodeDelegate((Z80A c, ref Register r) => { c.Restart(0x0038); })
        };
    }
}
