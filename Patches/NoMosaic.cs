using HarmonyLib;
using nel;

namespace AliceInCradleOverpowered.Patches
{
    [HarmonyPatch(typeof(MosaicShower), "FnDrawMosaic")]
    public class NoMosaic
    {
        public static bool Prefix() => !ModConfig.NoMosaic.Value;
    }
}
