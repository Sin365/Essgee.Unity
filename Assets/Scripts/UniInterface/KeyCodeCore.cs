using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class KeyCodeCore
{
    public Dictionary<KeyCode, MotionKey> dictKeyCfgs = new Dictionary<KeyCode, MotionKey>();
    public KeyCode[] CheckList;
    public MotionKey[] mCurrKey = new MotionKey[0];
    //public ulong CurryInpuAllData = 0;
    List<MotionKey> temp = new List<MotionKey>();
    ulong tempInputAllData = 0;
    UniKeyboard mUniKeyboard;
    //bool bReplayMode;
    //List<MotionKey> ReplayCheckKey = new List<MotionKey>();

    ulong last_CurryInpuAllData_test = 0;

    public MotionKey[] GetPressedKeys()
    {
        return mCurrKey;

        //        if (!bReplayMode)
        //        {
        //            //UMAME.instance.mReplayWriter.NextFramebyFrameIdx((int)UMAME.instance.mUniVideoPlayer.mFrame, CurryInpuAllData);
        //            UMAME.instance.mReplayWriter.NextFramebyFrameIdx((int)UMAME.instance.mUniVideoPlayer.mFrame, CurryInpuAllData);

        //#if UNITY_EDITOR
        //            if (last_CurryInpuAllData_test != CurryInpuAllData)
        //            {
        //                last_CurryInpuAllData_test = CurryInpuAllData;
        //                string TempStr = "";
        //                foreach (var item in mCurrKey)
        //                {
        //                    TempStr += $"{item.ToString()}|";
        //                }
        //                if (!string.IsNullOrEmpty(TempStr))
        //                    Debug.Log($"{UMAME.instance.mUniVideoPlayer.mFrame} |   Input-> {TempStr}");
        //                else
        //                    Debug.Log($"{UMAME.instance.mUniVideoPlayer.mFrame} |   Input-> 0");
        //            }
        //#endif
        //            return mCurrKey;
        //        }
        //        else
        //        {
        //            //有变化

        //            //if (UMAME.instance.mReplayReader.NextFrame(out AxiReplay.ReplayStep stepData))
        //            if (UMAME.instance.mReplayReader.NextFramebyFrameIdx((int)UMAME.instance.mUniVideoPlayer.mFrame, out AxiReplay.ReplayStep stepData))
        //            {
        //                temp.Clear();
        //                //有数据
        //                for (int i = 0; i < ReplayCheckKey.Count; i++)
        //                {
        //                    if ((stepData.InPut & (ulong)ReplayCheckKey[i]) > 0)
        //                        temp.Add(ReplayCheckKey[i]);
        //                }
        //                mCurrKey = temp.ToArray();


        //#if UNITY_EDITOR
        //                string TempStr = "";
        //                foreach (var item in mCurrKey)
        //                {
        //                    TempStr += $"{item.ToString()}|";
        //                }
        //                if (!string.IsNullOrEmpty(TempStr))
        //                    Debug.Log($"{UMAME.instance.mUniVideoPlayer.mFrame} |   Input-> {TempStr}");
        //                else
        //                    Debug.Log($"{UMAME.instance.mUniVideoPlayer.mFrame} |   Input-> 0");
        //#endif
        //            }

        //            return mCurrKey;
        //        }
    }

    public void SetRePlay(bool IsReplay)
    {
        //bReplayMode = IsReplay;
    }
    public void Init(Essgee.Emulation.Machines.IMachine Machine, UniKeyboard uniKeyboard, bool IsReplay)
    {
        //bReplayMode = IsReplay;
        mUniKeyboard = uniKeyboard;
        //foreach (MotionKey mkey in Enum.GetValues(typeof(MotionKey)))
        //{
        //    ReplayCheckKey.Add(mkey);
        //}
        dictKeyCfgs.Clear();
        //dictKeyCfgs.Add(KeyCode.P, MotionKey.EMU_PAUSED);
        if (Machine is Essgee.Emulation.Machines.MasterSystem)
        {
            var machine = (Essgee.Emulation.Machines.MasterSystem)Machine;
            dictKeyCfgs.Add(KeyCode.W, machine.configuration.Joypad1Up);
            dictKeyCfgs.Add(KeyCode.S, machine.configuration.Joypad1Down);
            dictKeyCfgs.Add(KeyCode.A, machine.configuration.Joypad1Left);
            dictKeyCfgs.Add(KeyCode.D, machine.configuration.Joypad1Right);
            dictKeyCfgs.Add(KeyCode.J, machine.configuration.Joypad1Button1);
            dictKeyCfgs.Add(KeyCode.K, machine.configuration.Joypad1Button2);

            dictKeyCfgs.Add(KeyCode.UpArrow, machine.configuration.Joypad2Up);
            dictKeyCfgs.Add(KeyCode.DownArrow, machine.configuration.Joypad2Down);
            dictKeyCfgs.Add(KeyCode.LeftArrow, machine.configuration.Joypad2Left);
            dictKeyCfgs.Add(KeyCode.RightAlt, machine.configuration.Joypad2Right);
            dictKeyCfgs.Add(KeyCode.Alpha1, machine.configuration.Joypad2Button1);
            dictKeyCfgs.Add(KeyCode.Alpha2, machine.configuration.Joypad2Button2);
        }
        else if (Machine is Essgee.Emulation.Machines.GameBoy)
        {
            var machine = (Essgee.Emulation.Machines.GameBoy)Machine;

            dictKeyCfgs.Add(KeyCode.W, machine.configuration.ControlsUp);
            dictKeyCfgs.Add(KeyCode.S, machine.configuration.ControlsDown);
            dictKeyCfgs.Add(KeyCode.A, machine.configuration.ControlsLeft);
            dictKeyCfgs.Add(KeyCode.D, machine.configuration.ControlsRight);
            dictKeyCfgs.Add(KeyCode.J, machine.configuration.ControlsB);
            dictKeyCfgs.Add(KeyCode.K, machine.configuration.ControlsA);

            dictKeyCfgs.Add(KeyCode.Return, machine.configuration.ControlsStart);
            dictKeyCfgs.Add(KeyCode.RightShift, machine.configuration.ControlsSelect);
        }
        else if (Machine is Essgee.Emulation.Machines.GameBoyColor)
        {
            var machine = (Essgee.Emulation.Machines.GameBoyColor)Machine;

            dictKeyCfgs.Add(KeyCode.W, machine.configuration.ControlsUp);
            dictKeyCfgs.Add(KeyCode.S, machine.configuration.ControlsDown);
            dictKeyCfgs.Add(KeyCode.A, machine.configuration.ControlsLeft);
            dictKeyCfgs.Add(KeyCode.D, machine.configuration.ControlsRight);
            dictKeyCfgs.Add(KeyCode.J, machine.configuration.ControlsB);
            dictKeyCfgs.Add(KeyCode.K, machine.configuration.ControlsA);

            dictKeyCfgs.Add(KeyCode.Return, machine.configuration.ControlsStart);
            dictKeyCfgs.Add(KeyCode.RightShift, machine.configuration.ControlsSelect);
            dictKeyCfgs.Add(KeyCode.Space, machine.configuration.ControlsSendIR);
        }
        else if (Machine is Essgee.Emulation.Machines.GameGear)
        {
            var machine = (Essgee.Emulation.Machines.GameGear)Machine;
            dictKeyCfgs.Add(KeyCode.W, machine.configuration.ControlsUp);
            dictKeyCfgs.Add(KeyCode.S, machine.configuration.ControlsDown);
            dictKeyCfgs.Add(KeyCode.A, machine.configuration.ControlsLeft);
            dictKeyCfgs.Add(KeyCode.D, machine.configuration.ControlsRight);
            dictKeyCfgs.Add(KeyCode.J, machine.configuration.ControlsButton2);
            dictKeyCfgs.Add(KeyCode.K, machine.configuration.ControlsButton1);
            dictKeyCfgs.Add(KeyCode.Return, machine.configuration.ControlsStart);
        }
        else if (Machine is Essgee.Emulation.Machines.SC3000)
        {
            var machine = (Essgee.Emulation.Machines.SC3000)Machine;

            /*
             * InputReset = MotionKey.F12;
			InputChangeMode = MotionKey.F1;
			InputPlayTape = MotionKey.F2;

			Joypad1Up = MotionKey.Up;
			Joypad1Down = MotionKey.Down;
			Joypad1Left = MotionKey.Left;
			Joypad1Right = MotionKey.Right;
			Joypad1Button1 = MotionKey.A;
			Joypad1Button2 = MotionKey.S;

			Joypad2Up = MotionKey.NumPad8;
			Joypad2Down = MotionKey.NumPad2;
			Joypad2Left = MotionKey.NumPad4;
			Joypad2Right = MotionKey.NumPad6;
			Joypad2Button1 = MotionKey.NumPad1;
			Joypad2Button2 = MotionKey.NumPad3;
             */

            //dictKeyCfgs.Add(KeyCode.F12, machine.configuration.InputReset);
            dictKeyCfgs.Add(KeyCode.F1, machine.configuration.InputChangeMode);
            dictKeyCfgs.Add(KeyCode.F2, machine.configuration.InputPlayTape);

            dictKeyCfgs.Add(KeyCode.W, machine.configuration.Joypad1Up);
            dictKeyCfgs.Add(KeyCode.S, machine.configuration.Joypad1Down);
            dictKeyCfgs.Add(KeyCode.A, machine.configuration.Joypad1Left);
            dictKeyCfgs.Add(KeyCode.D, machine.configuration.Joypad1Right);
            dictKeyCfgs.Add(KeyCode.J, machine.configuration.Joypad1Button2);
            dictKeyCfgs.Add(KeyCode.K, machine.configuration.Joypad1Button1);

            dictKeyCfgs.Add(KeyCode.UpArrow, machine.configuration.Joypad2Up);
            dictKeyCfgs.Add(KeyCode.DownArrow, machine.configuration.Joypad2Down);
            dictKeyCfgs.Add(KeyCode.LeftArrow, machine.configuration.Joypad2Left);
            dictKeyCfgs.Add(KeyCode.RightAlt, machine.configuration.Joypad2Right);
            dictKeyCfgs.Add(KeyCode.Alpha1, machine.configuration.Joypad2Button1);
            dictKeyCfgs.Add(KeyCode.Alpha2, machine.configuration.Joypad2Button2);
        }
        else if (Machine is Essgee.Emulation.Machines.SG1000)
        {
            var machine = (Essgee.Emulation.Machines.SG1000)Machine;

            /*
             TVStandard = TVStandard.NTSC;

			InputPause = MotionKey.Space;

			Joypad1Up = MotionKey.Up;
			Joypad1Down = MotionKey.Down;
			Joypad1Left = MotionKey.Left;
			Joypad1Right = MotionKey.Right;
			Joypad1Button1 = MotionKey.A;
			Joypad1Button2 = MotionKey.S;

			Joypad2Up = MotionKey.NumPad8;
			Joypad2Down = MotionKey.NumPad2;
			Joypad2Left = MotionKey.NumPad4;
			Joypad2Right = MotionKey.NumPad6;
			Joypad2Button1 = MotionKey.NumPad1;
			Joypad2Button2 = MotionKey.NumPad3;
             */

            dictKeyCfgs.Add(KeyCode.W, machine.configuration.Joypad1Up);
            dictKeyCfgs.Add(KeyCode.S, machine.configuration.Joypad1Down);
            dictKeyCfgs.Add(KeyCode.A, machine.configuration.Joypad1Left);
            dictKeyCfgs.Add(KeyCode.D, machine.configuration.Joypad1Right);
            dictKeyCfgs.Add(KeyCode.J, machine.configuration.Joypad1Button2);
            dictKeyCfgs.Add(KeyCode.K, machine.configuration.Joypad1Button1);

            dictKeyCfgs.Add(KeyCode.UpArrow, machine.configuration.Joypad2Up);
            dictKeyCfgs.Add(KeyCode.DownArrow, machine.configuration.Joypad2Down);
            dictKeyCfgs.Add(KeyCode.LeftArrow, machine.configuration.Joypad2Left);
            dictKeyCfgs.Add(KeyCode.RightAlt, machine.configuration.Joypad2Right);
            dictKeyCfgs.Add(KeyCode.Alpha1, machine.configuration.Joypad2Button2);
            dictKeyCfgs.Add(KeyCode.Alpha2, machine.configuration.Joypad2Button1);
        }
        CheckList = dictKeyCfgs.Keys.ToArray();


        //mUniKeyboard.btnP1.Key = new long[] { (long)MotionKey.P1_GAMESTART };
        //mUniKeyboard.btnCoin1.Key = new long[] { (long)MotionKey.P1_INSERT_COIN };
        //mUniKeyboard.btnA.Key = new long[] { (long)MotionKey.P1_BTN_1 };
        //mUniKeyboard.btnB.Key = new long[] { (long)MotionKey.P1_BTN_2 };
        //mUniKeyboard.btnC.Key = new long[] { (long)MotionKey.P1_BTN_3 };
        //mUniKeyboard.btnD.Key = new long[] { (long)MotionKey.P1_BTN_4 };
        ////mUniKeyboard.btnE.Key = new long[] { (long)MotionKey.P1_BTN_5 };
        ////mUniKeyboard.btnF.Key = new long[] { (long)MotionKey.P1_BTN_6 };
        //mUniKeyboard.btnAB.Key = new long[] { (long)MotionKey.P1_BTN_1, (long)MotionKey.P1_BTN_2 };
        //mUniKeyboard.btnCD.Key = new long[] { (long)MotionKey.P1_BTN_3, (long)MotionKey.P1_BTN_4 };
        //mUniKeyboard.btnABC.Key = new long[] { (long)MotionKey.P1_BTN_1, (long)MotionKey.P1_BTN_2, (long)MotionKey.P1_BTN_3 };
    }

    public void UpdateLogic()
    {
        //if (bReplayMode) return;
        tempInputAllData = 0;
        temp.Clear();
        for (int i = 0; i < CheckList.Length; i++)
        {
            if (Input.GetKey(CheckList[i]))
            {
                MotionKey mk = dictKeyCfgs[CheckList[i]];
                temp.Add(mk);
                tempInputAllData |= (ulong)mk;
            }
        }

        //for (int i = 0; i < mUniKeyboard.mUIBtns.Count; i++)
        //{
        //    if (mUniKeyboard.mUIBtns[i].bHotKey)
        //    {
        //        for (int j = 0; j < mUniKeyboard.mUIBtns[i].Key.Length; j++)
        //        {
        //            MotionKey mk = (MotionKey)mUniKeyboard.mUIBtns[i].Key[j];
        //            temp.Add(mk);
        //            tempInputAllData |= (ulong)mk;
        //        }
        //    }
        //}

        //Vector2Int inputV2 = mUniKeyboard.mJoystick.RawInputV2;
        ////Debug.Log($"{inputV2.x},{inputV2.y}");
        //if (inputV2.x > 0)
        //{
        //    temp.Add(MotionKey.P1_RIGHT);
        //    tempInputAllData |= (ulong)MotionKey.P1_RIGHT;
        //}
        //else if (inputV2.x < 0)
        //{
        //    temp.Add(MotionKey.P1_LEFT);
        //    tempInputAllData |= (ulong)MotionKey.P1_LEFT;
        //}
        //if (inputV2.y > 0)
        //{
        //    temp.Add(MotionKey.P1_UP);
        //    tempInputAllData |= (ulong)MotionKey.P1_UP;
        //}
        //else if (inputV2.y < 0)
        //{
        //    temp.Add(MotionKey.P1_DOWN);
        //    tempInputAllData |= (ulong)MotionKey.P1_DOWN;
        //}
        //CurryInpuAllData = tempInputAllData;
        mCurrKey = temp.ToArray();

    }
}