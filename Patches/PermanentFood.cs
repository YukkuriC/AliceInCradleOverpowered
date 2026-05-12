// 生成于 GLM-5V-Turbo
using HarmonyLib;
using nel;

namespace AliceInCradleOverpowered.Patches
{
    [HarmonyPatch]
    public static class PermanentFood
    {
        static bool generalCanceller<T>(ref T overrider, T value)
        {
            if (!ModConfig.NoConsumeFood.Value)
                return true;
            overrider = value;
            return false;
        }

        [HarmonyPrefix, HarmonyPatch(typeof(UiLunchTimeBase), "ReduceFromInventorySrc")]
        public static bool NoUseDecrease(ItemStorage Str, NelItem _Itm, ItemStorage.ObtainInfo StrObt, ref bool __result)
        {
            return generalCanceller(ref __result, false);
        }

        [HarmonyPatch(typeof(NelItemManager), "createWlinkPack", typeof(ItemStorage), typeof(ItemStorage.IRow), typeof(int), typeof(ItemStorage), typeof(ItemStorage.IRow), typeof(int))]
        public static bool NoComsumeInBox(ref string __result)
        {
            return generalCanceller(ref __result, null);
        }
    }
}
