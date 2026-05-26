// 生成于 GLM-5V-Turbo
using System.Collections.Generic;
using System.Diagnostics;

namespace AliceInCradleOverpowered
{
    public static class Helpers
    {
        public static string GetCaller(int layerUp = 0)
        {
            var frame = new StackFrame(2 + layerUp, false);
            return frame.GetMethod()?.Name ?? "";
        }

        public static bool IsCalledBy(string funcName) => GetCaller() == funcName;

        public static bool IsCalledByAny(IEnumerable<string> funcNames)
        {
            var caller = GetCaller();
            foreach (var name in funcNames)
                if (caller == name) return true;
            return false;
        }
    }
}
