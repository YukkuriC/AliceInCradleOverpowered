// 生成于 GLM-5V-Turbo
using HarmonyLib;
using nel;
using System.Diagnostics;

namespace AliceInCradleOverpowered.Patches
{
    [HarmonyPatch]
    public static class PermanentConsumable
    {
        static readonly string[] UseCallers = { "useItemOnCurrentCursor", "fnClickItemCmd" };

        [HarmonyPrefix, HarmonyPatch(typeof(ItemStorage), "Reduce", typeof(NelItem), typeof(int), typeof(int), typeof(bool))]
        public static bool NoConsume(NelItem Itm, ref bool __result)
        {
            if (!ModConfig.PermanentThrowable.Value || Itm == null || !Itm.useable || Itm.is_food)
                return true;
            var caller = new StackFrame(2, false).GetMethod()?.Name ?? "";
            foreach (var c in UseCallers)
                if (caller == c) { __result = true; return false; }
            return true;
        }
    }
}
