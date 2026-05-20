// 生成于 GLM-5V-Turbo
using HarmonyLib;
using m2d;
using nel;
using XX;

namespace AliceInCradleOverpowered.Patches
{
    [HarmonyPatch]
    public static class SuperWaterShard
    {
        static float _timer;
        const float INTERVAL = 10f;

        static bool ShouldUpdateShield(M2PrSkill skill)
        {
            if (skill?.Pr == null) return false;
            var pr = skill.Pr;
            if (
                pr.isSleepState()
                || pr.isSinkState()
                || pr.isDownState()
                || pr.isPoseDown()
                || pr.isFrozen()
                || pr.isStoneSer()
                || pr.Ser?.isStun() == true
            ) return true;
            return EnemySummoner.isActiveBorder();
        }

        [HarmonyPostfix, HarmonyPatch(typeof(M2PrSkill), "runPre")]
        public static void AutoShield(M2PrSkill __instance)
        {
            if (!ModConfig.WaterShardShield.Value) return;
            var skill = __instance;
            if (skill?.Pr == null) return;

            _timer += skill.Pr.TS;
            if (!ShouldUpdateShield(skill)) return;
            if (_timer < INTERVAL)
                return;
            _timer = 0f;

            var mgc = skill.NM2D.MGC;
            if (mgc.countMg(HasActiveShard, skill.Pr) > 0)
                return;

            if (!skill.MagicSel.isObtained(MGKIND.WATERSHARD))
                skill.setMagicObtainFlag(MGKIND.WATERSHARD, 0);

            var parent = mgc.setMagic(skill.Pr, MGKIND.WATERSHARD, MGHIT.PR | MGHIT.IMMEDIATE);
            parent.run(1f);
            var family = parent.Other as MgWaterShard.ShardFamily;
            if (family == null)
                return;
            while (family.rest_appear_count > 0)
            {
                var shard = parent.createNewMagic(parent, MGKIND.WATERSHARD, parent.Cen.x, parent.Cen.y, false);
                shard.sa = parent.sa;
                shard.Other = family.Add(shard);
                shard.t = -8.2f;
                shard.Mn._0.no_draw = true;
                shard.Mn._1.other_hit = false;
            }
        }

        static bool HasActiveShard(MagicItem Mg, M2MagicCaster Caster)
        {
            return Mg.kind == MGKIND.WATERSHARD
                   && Mg.Caster == Caster
                   && !Mg.killed
                   && Mg.phase < 2000;
        }

        [HarmonyPostfix, HarmonyPatch(typeof(MgWaterShard), "run")]
        static void SpawnFireballOnHit(MagicItem Mg, float fcnt, bool __result)
        {
            if (__result) return;
            if (!ModConfig.WaterShardExplosive.Value) return;
            if (Mg?.Mp == null || Mg.MGC == null) return;
            int mphase = Mg.phase - Mg.phase % 100;
            if (mphase != 2000 && mphase != 2100) return;

            var fireball = Mg.MGC.setMagic(Mg.Caster, MGKIND.FIREBALL, MGHIT.PR | MGHIT.IMMEDIATE);
            fireball.sx = Mg.sx;
            fireball.sy = Mg.sy;
            fireball.sa = Mg.sa;
            fireball.run(1f);
        }
    }
}
