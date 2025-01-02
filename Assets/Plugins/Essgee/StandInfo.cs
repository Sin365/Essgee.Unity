
using Essgee;
using System;
using System.IO;

public static class StandInfo
{
    const string jsonConfigFileName = "Config.json";
    const string saveDataDirectoryName = "Saves";
    const string screenshotDirectoryName = "Screenshots";
    const string saveStateDirectoryName = "Savestates";
    const string extraDataDirectoryName = "Extras";
    static string ProductName = "";

    readonly static string programDataDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), ProductName);
    readonly static string programConfigPath = Path.Combine(programDataDirectory, jsonConfigFileName);

    public static Configuration Configuration { get; set; }

    public static string ShaderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Shaders");
    public static string SaveDataPath = Path.Combine(programDataDirectory, saveDataDirectoryName);
    public static string ScreenshotPath = Path.Combine(programDataDirectory, screenshotDirectoryName);
    public static string SaveStatePath = Path.Combine(programDataDirectory, saveStateDirectoryName);
    public static string ExtraDataPath = Path.Combine(programDataDirectory, extraDataDirectoryName);

    static Random mRandom;
    public static Random Random
    {
        get
        {
            if (mRandom == null)
            {
                mRandom = new Random();
            }
            return mRandom;
        }
    }

    public static string ProductVersion { get; internal set; }
}