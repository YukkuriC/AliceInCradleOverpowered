using BepInEx;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
            patcher = new Harmony(UID);
            patcher.PatchAll();

            // configs
            ModConfig.Init(Config);
        }
    }
}
