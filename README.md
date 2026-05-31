# 孤影刀客
基于 Unity 与 C# 开发的 2D 动作游戏 Demo。

## 项目简介
玩家将扮演一名刀客，通过移动、冲刺与连击击败敌人，并完成关卡挑战。
<img width="2487" height="1147" alt="image" src="https://github.com/user-attachments/assets/39f84251-a76c-4d65-a9ca-292b60b3c1f7" />

## 核心功能
* 玩家移动与翻转
* 二连击战斗系统
* Dash 冲刺与无敌帧
* 敌人 AI 追击与攻击
* 敌人受击、击退与死亡状态
* HitStop（顿帧）
* Camera Shake（镜头震动）
* 血量系统
* GameOver / Victory 流程

## 技术实现
* 状态机管理敌人行为
* 协程实现 Dash 与无敌帧
* 动画事件控制攻击判定
* 组件化设计拆分 Movement、Attack、Health 等系统

## 开发环境
* Unity
* C#
