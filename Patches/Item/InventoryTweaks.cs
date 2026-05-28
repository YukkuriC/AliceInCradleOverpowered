// 生成于 GLM-5V-Turbo
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using nel;
using XX;

namespace AliceInCradleOverpowered.Patches.Item
{
    [HarmonyPatch]
    public static class InventoryTweaks
    {
        static readonly HashSet<string> StackBlacklist = new HashSet<string>
        {
            "mtr_bottle0",
        };

        [HarmonyPostfix]
        [HarmonyPatch(typeof(ItemStorage), "getItemStockable")]
        public static void Postfix_AmplifyStackSize(NelItem Itm, ref int __result)
        {
            if (ModConfig.MaxStackMult.Value <= 1) return;
            if (Itm != null && StackBlacklist.Contains(Itm.key)) return;
            __result *= ModConfig.MaxStackMult.Value;
        }

        [HarmonyTranspiler]
        [HarmonyPatch(typeof(NelItem), "getCountString")]
        [HarmonyPatch(new[] { typeof(STB), typeof(int), typeof(ItemStorage) })]
        public static IEnumerable<CodeInstruction> Transpiler_DisplayThreshold(IEnumerable<CodeInstruction> instructions)
        {
            var getMaxMethod = typeof(InventoryTweaks).GetMethod(nameof(GetMaxDisplayStackSize), BindingFlags.Static | BindingFlags.Public);
            var list = instructions.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].LoadsConstant(100))
                    list[i] = new CodeInstruction(OpCodes.Call, getMaxMethod);
            }
            return list;
        }

        public static int GetMaxDisplayStackSize()
        {
            var entry = ModConfig.MaxStackMult;
            if (entry == null) return 100;
            return 100 * entry.Value;
        }
    }
}
