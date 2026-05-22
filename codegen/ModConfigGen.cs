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
            NoConsumeFood,
            PermanentThrowable,
            SortedReelContent,
            NoMosaic;

        public static void Init(ConfigFile config)
        {
            // Combat
            MeleeRangeRatio = config.Bind("Combat", "MeleeRangeRatio", 1f, "Melee attack horizontal ranges will be multiplied by this value");
            WaterShardShield = config.Bind("Combat", "WaterShardShield", true, "Auto supply water shards during combat");
            WaterShardExplosive = config.Bind("Combat", "WaterShardExplosive", true, "Water shards explode like fireballs on hit");
            // Item
            NoConsumeFood = config.Bind("Item", "NoConsumeFood", true, "Food won't be consumed on use");
            PermanentThrowable = config.Bind("Item", "PermanentThrowable", true, "Throwables won't be consumed on use");
            // Item/Reel
            SortedReelContent = config.Bind("Item/Reel", "SortedReelContent", true, "Force-sort reel content by effect type + intensity (weak→strong)");
            // Display
            NoMosaic = config.Bind("Display", "NoMosaic", true, "Disable dynamic mosaic");
        }
    }
}
