// 生成于 GLM-5V-Turbo
using HarmonyLib;
using nel;

namespace AliceInCradleOverpowered.Patches.Item
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
            if (Helpers.IsCalledByAny(UseCallers))
            {
                __result = true;
                return false;
            }
            return true;
        }
    }
}
