// 生成于 GLM-5V-Turbo
using System;
using System.Collections.Generic;
using HarmonyLib;
using nel;
using XX;

namespace AliceInCradleOverpowered.Patches
{
    [HarmonyPatch]
    public static class ReelTweaks
    {
        [HarmonyPostfix]
        [HarmonyPatch(typeof(ReelManager.EFReel), MethodType.Constructor)]
        [HarmonyPatch(new Type[] { typeof(List<string>), typeof(int) })]
        public static void SortEffectList(ReelManager.EFReel __instance)
        {
            if (!ModConfig.SortedReelContent.Value) return;
            var effect = __instance.Aeffect;
            if (effect == null || effect.Length <= 1) return;
            Array.Sort(effect);
        }
    }
}
