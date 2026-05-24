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
        [HarmonyPatch(new[] { typeof(List<string>), typeof(int) })]
        public static void SortEffectList(ReelManager.EFReel __instance)
        {
            if (!ModConfig.SortedReelContent.Value) return;
            var effect = __instance.Aeffect;
            if (effect == null || effect.Length <= 1) return;
            Array.Sort(effect);
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(ReelExecuter), "decideRotate")]
        public static void Postfix_AutoBestReel(ReelExecuter __instance)
        {
            if (!ModConfig.AutoBestReel.Value) return;
            if (__instance.etype == ReelExecuter.ETYPE.ITEMKIND) return;
            if (__instance.Acontent == null || __instance.Acontent.Length <= 1) return;
            bool isLucky = __instance.etype == ReelExecuter.ETYPE.RANDOM;
            if (isLucky && ModConfig.AutoBestReel_Lucky.Value == CfgAutoLuckyBag.Off) return;
            int bestIdx = -1;
            int bestVal = int.MinValue;
            for (int i = 0; i < __instance.Acontent.Length; i++)
            {
                if (!FEnum<ReelExecuter.EFFECT>.TryParse(__instance.Acontent[i], out var eff)) continue;
                if (isLucky)
                {
                    bool match = ModConfig.AutoBestReel_Lucky.Value switch
                    {
                        CfgAutoLuckyBag.Mult => eff >= ReelExecuter.EFFECT.COUNT_MUL1 && eff <= ReelExecuter.EFFECT.COUNT_MUL2,
                        CfgAutoLuckyBag.Rarity => eff >= ReelExecuter.EFFECT.GRADE0 && eff <= ReelExecuter.EFFECT.GRADE4,
                        _ => false,
                    };
                    if (!match) continue;
                }
                if ((int)eff > bestVal)
                {
                    bestVal = (int)eff;
                    bestIdx = i;
                }
            }
            if (bestIdx >= 0) __instance.content_id_dec = bestIdx;
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(UiReelManager), "runIRD")]
        public static void Postfix_AutoConfirm(UiReelManager __instance)
        {
            if (!ModConfig.AutoBestReel.Value) return;
            var id = __instance.rotate_decide_id;
            if (id < -1 || id >= __instance.AReel.Count) return;
            var reel = (id == -1) ? __instance.ReelIK : __instance.AReel[id];
            if (reel == null) return;
            var etype = reel.etype;
            if (etype == ReelExecuter.ETYPE.ITEMKIND) return;
            if (etype == ReelExecuter.ETYPE.RANDOM && ModConfig.AutoBestReel_Lucky.Value == CfgAutoLuckyBag.Off) return;
            if (__instance.decide_delay > 0f)
            {
                __instance.decide_delay = 0f;
                return;
            }
            if (reel.decideRotate())
            {
                __instance.rotate_decide_id = id + 1;
                if (id >= 0 && __instance.ReelIK != null)
                    __instance.ReelIK.applyEffectToIK(reel);
                if (id + 1 >= __instance.AReel.Count)
                {
                    __instance.PadVib("reel_decide_1", 1f);
                    var box = __instance.getCurrentItemReelDrawer();
                    if (box != null) box.animOpen();
                    if (__instance.Snd != null) __instance.Snd.Stop();
                }
                __instance.decide_delay = (id + 1 >= __instance.AReel.Count) ? 24f : 6f;
            }
        }
    }
}
