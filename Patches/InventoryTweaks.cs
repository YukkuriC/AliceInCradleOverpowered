// 生成于 GLM-5V-Turbo
using HarmonyLib;
using nel;

namespace AliceInCradleOverpowered.Patches
{
    [HarmonyPatch]
    public static class InventoryTweaks
    {
        [HarmonyPostfix]
        [HarmonyPatch(typeof(ItemStorage), "getItemStockable")]
        public static void Postfix_AmplifyStackSize(NelItem Itm, ref int __result)
        {
            if (ModConfig.MaxStackMult.Value <= 1) return;
            __result *= ModConfig.MaxStackMult.Value;
        }
    }
}
