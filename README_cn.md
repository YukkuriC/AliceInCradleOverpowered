# AliceInCradleOverpowered

**中文** [English](README.md)

> 生成于 GLM-5V-Turbo

AliceInCradle 游戏的强化模组。

## 依赖

- 基础游戏 [AliceInCradle](https://cn.aliceincradle.dev/download/)
- 最新版 [BepInEx](https://github.com/BepInEx/BepInEx/releases/latest)

## 功能

- **战斗**
  - 扩展近战攻击范围（`MeleeRangeRatio`）
  - 战斗中自动补充水之碎片（`WaterShardShield`）
  - 命中时水之碎片像火球一样爆裂（`WaterShardExplosive`）
  - **插件**
    - 强制增加更多插件/装备槽位（`MoreEnhancers`）
- **物品**
  - 使用食物不会消耗（`NoConsumeFood`）
  - 食物饥饿条不会减少（`PermanentFoodBuff`）
  - 使用投掷物不会消耗（`PermanentThrowable`）
  - 放大背包中物品的最大堆叠数量（`MaxStackMult`）
  - **轮盘**
    - 按效果强度排序轮盘内容（`SortedReelContent`）
    - 奖励轮盘停止时自动选择最强效果，不含福袋/物品轮盘（`AutoBestReel`）
    - 福袋轮盘自动选择最优效果（`AutoBestReel_Lucky`）
    - 提升宝箱奖励数量上限（原版上限：99）（`MaxTreasureRewards`）
    - 将数量增加轮盘移到列表前面（`IncReelsFirst`）
- **显示**
  - 移除动态马赛克（`NoMosaic`）
  - 抑制启动时错误日志检测（`SuppressStartupErrorLogHint`）
  - 启用Harmony文件日志输出到游戏根目录（`EnableHarmonyLogs`）

## 部署

1. 克隆仓库
2. 复制 `path.example.props` 到 `path.props` 并将 `PATH/TO/GAME/ROOT` 替换为你实际的 AliceInCradle 游戏安装路径
3. 使用你喜欢的 IDE 或构建工具构建项目
