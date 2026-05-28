// 生成于 GLM-5V-Turbo
using HarmonyLib;
using XX;

namespace AliceInCradleOverpowered.Patches
{
    [HarmonyPatch(typeof(Logger), "InitLogger")]
    public static class SuppressErrorReporter
    {
        public static void Postfix()
        {
            if (!ModConfig.SuppressStartupErrorLogHint.Value) return;
            Logger.error_occur_path = null;
            Logger.loaded_file_error_flag = Logger.ERRORFLAG.NONE;
        }
    }
}
