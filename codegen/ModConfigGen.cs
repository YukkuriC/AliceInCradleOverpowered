using BepInEx.Configuration;

namespace AliceInCradleOverpowered
{
    public static partial class ModConfig
    {
        public static ConfigEntry<float>
            MeleeRangeRatio;
        public static ConfigEntry<bool>
            PermanentFood,
            PermanentThrowable,
            NoMosaic;

        public static void Init(ConfigFile config)
        {
            // Combat
            MeleeRangeRatio = config.Bind("Combat", "MeleeRangeRatio", 1f, "Melee attack horizontal ranges will be multiplied by this value");
            PermanentFood = config.Bind("Combat", "PermanentFood", true, "Food won't be consumed on use");
            PermanentThrowable = config.Bind("Combat", "PermanentThrowable", true, "Throwables won't be consumed on use");
            // Display
            NoMosaic = config.Bind("Display", "NoMosaic", true, "Disable dynamic mosaic renderer");
        }
    }
}
