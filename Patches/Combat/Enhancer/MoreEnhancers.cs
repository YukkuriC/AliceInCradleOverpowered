// 生成于 GLM-5V-Turbo
using HarmonyLib;
using nel;

namespace AliceInCradleOverpowered.Patches.Combat.Enhancer
{
    [HarmonyPatch]
    public static class MoreEnhancers
    {
        static NelItem _slotItem;

        [HarmonyPostfix, HarmonyPatch(typeof(ItemStorage), "getCount", typeof(NelItem), typeof(int))]
        public static void Postfix_GetCount(NelItem Data, ref int __result)
        {
            if (!ModConfig.MoreEnhancers.Value || Data == null) return;
            if (_slotItem == null) _slotItem = NelItem.GetById("enhancer_slot", false);
            if (Data != _slotItem) return;
            if (!Helpers.IsCalledBy("fineEnhancerStorage")) return;
            __result += 100;
        }
    }
}
