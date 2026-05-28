using BepInEx.Configuration;

namespace AliceInCradleOverpowered
{
    public static partial class ModConfig
    {
        public static ConfigEntry<float>
            MeleeRangeRatio;
        public static ConfigEntry<bool>
            WaterShardShield,
            WaterShardExplosive,
            MorePlugins,
            NoConsumeFood,
            PermanentFoodBuff,
            PermanentThrowable,
            SortedReelContent,
            AutoBestReel,
            IncReelsFirst,
            NoMosaic,
            SuppressStartupErrorLogHint,
            EnableHarmonyLogs;
        public static ConfigEntry<int>
            MaxStackMult,
            MaxTreasureRewards;
        public static ConfigEntry<CfgAutoLuckyBag>
            AutoBestReel_Lucky;

        public static void Init(ConfigFile config)
        {
            // Combat
            MeleeRangeRatio = config.Bind("Combat", "MeleeRangeRatio", 1f, "Melee attack horizontal ranges will be multiplied by this value");
            WaterShardShield = config.Bind("Combat", "WaterShardShield", true, "Auto supply water shards during combat");
            WaterShardExplosive = config.Bind("Combat", "WaterShardExplosive", true, "Water shards explode like fireballs on hit");
            // Combat/Plugin
            MorePlugins = config.Bind("Combat/Plugin", "MorePlugins", true, "Force-added more slots to equip more plugins");
            // Item
            NoConsumeFood = config.Bind("Item", "NoConsumeFood", true, "Food won't be consumed on use");
            PermanentFoodBuff = config.Bind("Item", "PermanentFoodBuff", true, "Food hunger bar won't decrease");
            PermanentThrowable = config.Bind("Item", "PermanentThrowable", true, "Throwables won't be consumed on use");
            MaxStackMult = config.Bind("Item", "MaxStackMult", 10, "Multiplier for all item max stack sizes in inventory");
            // Item/Reel
            MaxTreasureRewards = config.Bind("Item/Reel", "MaxTreasureRewards", 999, "Upper limit for treasure chest reward count (original game limit is 99)");
            SortedReelContent = config.Bind("Item/Reel", "SortedReelContent", true, "Force-sort reel content by effect type + intensity (weak -> strong)");
            AutoBestReel = config.Bind("Item/Reel", "AutoBestReel", true, "Auto-select the strongest effect on bonus reel stop (excludes lucky bag/item reels)");
            AutoBestReel_Lucky = config.Bind("Item/Reel", "AutoBestReel_Lucky", CfgAutoLuckyBag.Mult, "Auto-select the best effect for lucky bag reels");
            IncReelsFirst = config.Bind("Item/Reel", "IncReelsFirst", true, "Move quantity-increase reels to the front of the list (applies on load and when adding new reels)");
            // Display
            NoMosaic = config.Bind("Display", "NoMosaic", true, "Disable dynamic mosaic");
            SuppressStartupErrorLogHint = config.Bind("Display", "SuppressStartupErrorLogHint", true, "Disable error log detection window on startup");
            EnableHarmonyLogs = config.Bind("Display", "EnableHarmonyLogs", false, "Enable Harmony file log output to game root directory");
        }
    }
}
