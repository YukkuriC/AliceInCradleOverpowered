// 生成于 GLM-5V-Turbo
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using nel;
using XX;

namespace AliceInCradleOverpowered.Patches
{
    [HarmonyPatch]
    public static class MoreTreasureRewards
    {
        [HarmonyTranspiler]
        [HarmonyPatch(typeof(ReelExecuter), "applyEffectToIK")]
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            var mnMethod = AccessTools.Method(typeof(X), "Mn", new[] { typeof(int), typeof(int) });
            var getMaxMethod = typeof(MoreTreasureRewards).GetMethod(nameof(GetMaxReward), BindingFlags.Static | BindingFlags.Public);
            var list = instructions.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].LoadsConstant(99) && i + 1 < list.Count && list[i + 1].Calls(mnMethod))
                    list[i] = new CodeInstruction(OpCodes.Call, getMaxMethod);
            }
            return list;
        }

        public static int GetMaxReward()
        {
            var entry = ModConfig.MaxTreasureRewards;
            if (entry == null) return 999;
            return entry.Value;
        }
    }
}
