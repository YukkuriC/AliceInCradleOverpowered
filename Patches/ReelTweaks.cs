// 生成于 GLM-5V-Turbo
using System;
using HarmonyLib;
using nel;
using XX;

namespace AliceInCradleOverpowered.Patches
{
    [HarmonyPatch]
    public static class ReelTweaks
    {
        [HarmonyPostfix, HarmonyPatch(typeof(ReelExecuter), "initReelContent")]
        public static void SortContent(ReelExecuter __instance)
        {
            if (!ModConfig.SortedReelContent.Value) return;
            var content = __instance.Acontent;
            if (content == null || content.Length <= 1) return;
            if (__instance.etype == ReelExecuter.ETYPE.ITEMKIND) return;
            Array.Sort(content);
        }
    }
}
