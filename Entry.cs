using BepInEx;
using HarmonyLib;

namespace AliceInCradleOverpowered
{
    using static ModConfig;

    public static partial class ModConfig
    {
        public const string UID = "yukkuric.aic.aicop";
        public const string NAME = "AiC Overpowered";
        public const string VERSION = "1.0.0";
    }

    [BepInPlugin(UID, NAME, VERSION)]
    [BepInProcess("AliceInCradle.exe")]
    public class Entry : BaseUnityPlugin
    {
        static Harmony patcher;

        void Awake()
        {
            // configs MUST be initialized before PatchAll so Transpilers can read them
            ModConfig.Init(Config);

            patcher = new Harmony(UID);
            // HarmonyFileLog.Enabled = true;
            patcher.PatchAll();
        }
    }
}
