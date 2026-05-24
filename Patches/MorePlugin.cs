// 生成于 Claude Opus 4.6
using HarmonyLib;
using nel;
using System.Diagnostics;

namespace AliceInCradleOverpowered.Patches
{
    [HarmonyPatch]
    public static class MorePlugin
    {
        static NelItem _slotItem;

        [HarmonyPostfix, HarmonyPatch(typeof(ItemStorage), "getCount", typeof(NelItem), typeof(int))]
        public static void Postfix_GetCount(NelItem Data, ref int __result)
        {
            if (!ModConfig.MorePlugins.Value || Data == null) return;
            if (_slotItem == null) _slotItem = NelItem.GetById("enhancer_slot", false);
            if (Data != _slotItem) return;
            var caller = new StackFrame(2, false).GetMethod()?.Name ?? "";
            if (caller != "fineEnhancerStorage") return;
            __result += 100;
        }
    }
}
