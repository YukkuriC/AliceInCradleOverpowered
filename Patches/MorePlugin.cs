// 生成于 GLM-5V-Turbo
using HarmonyLib;
using nel;

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
            if (!Helpers.IsCalledBy("fineEnhancerStorage")) return;
            __result += 100;
        }
    }
}
