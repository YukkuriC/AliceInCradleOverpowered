// 生成于 GLM-5V-Turbo
using System.Collections.Generic;
using System.Diagnostics;

namespace AliceInCradleOverpowered
{
    public static class Helpers
    {
        /*
         * 典型调用栈 (以"想检查的目标方法"为基准层 [0], 向上为负数):
         *
         * 场景: Harmony 一级补丁(Prefix/Postfix/Finalizer)内直接调用
         *   [-4] GetCaller                    ← 工具自身
         *   [-3] IsCalledBy / IsCalledByAny   ← 包装函数 (比 GetCaller 多 1 层)
         *   [-2] Patch_XXX                    ← 补丁方法
         *   [-1] <HarmonyWrapper>             ← Harmony 注入的代理层 (固定消耗 1 层)
         *   [0]  CallerOfOriginalMethod       ← 默认检查目标 (layerUp=0 时落在此处)
         */

        public static string GetCaller(int layerUp = 0)
        {
            var frame = new StackFrame(3 + layerUp, false);
            return frame.GetMethod()?.Name ?? "";
        }

        /// <param name="funcName">目标方法名</param>
        /// <param name="layerUp">在默认基础上额外向上追溯的层数</param>
        /// <returns>调用链中指定位置的方法名是否匹配 funcName</returns>
        ///
        /// 典型用法:
        ///   // 示例1: 一级补丁内, 检查原方法的调用方是否为某函数 (默认行为, 最常用)
        ///   IsCalledBy("someFunction")          → layerUp=0, 检查 [0] 层
        ///
        ///   // 示例2: 普通非补丁函数内, 查看直接上级函数 (无 HarmonyWrapper, 需回退 1 层)
        ///   IsCalledBy("expectedCaller", -1)    → 检查 [-1] 层, 即直接调用者
        ///
        ///   // 示例3: 补丁内通过辅助函数间接调用, 从辅助函数内检查原方法调用方
        ///   IsCalledBy("someFunction", 1)       → 额外跳过辅助函数, 检查 [+1] 层
        public static bool IsCalledBy(string funcName, int layerUp = 0) => GetCaller(layerUp + 1) == funcName;

        public static bool IsCalledByAny(IEnumerable<string> funcNames, int layerUp = 0)
        {
            var caller = GetCaller(layerUp + 1);
            foreach (var name in funcNames)
                if (caller == name) return true;
            return false;
        }
    }
}
