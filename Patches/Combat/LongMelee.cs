// 生成于 GLM-5V-Turbo
using HarmonyLib;
using nel;

namespace AliceInCradleOverpowered.Patches.Combat
{
    [HarmonyPatch(typeof(PrCaneEquip), nameof(PrCaneEquip.reach_ratio))]
    public class LongMelee
    {
        public static void Postfix(ref float __result)
        {
            __result *= ModConfig.MeleeRangeRatio.Value;
        }
    }
}
