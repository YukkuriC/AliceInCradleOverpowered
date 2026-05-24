using BepInEx;
using HarmonyLib;
using System;

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
            // 生成于 GLM-5V-Turbo
            try
            {
                patcher.PatchAll();
                Logger.LogInfo("PatchAll completed successfully");
            }
            catch (Exception ex)
            {
                Logger.LogError($"PatchAll failed: {ex}");
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    Logger.LogError($"Inner exception: {ex}");
                }
            }
        }
    }
}
