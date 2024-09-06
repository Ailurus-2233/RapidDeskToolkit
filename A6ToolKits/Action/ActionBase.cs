﻿using System;
using System.Threading.Tasks;
using Avalonia.Media;

namespace A6ToolKits.Action;

/// <summary>
/// 基于 IAction 接口的抽象类，提供了一些默认实现
/// </summary>
public abstract class ActionBase : IAction
{
    /// <summary>
    /// 动作名称
    /// </summary>
    public virtual string Name { get; init; } = string.Empty;

    /// <summary>
    /// 动作工具提示
    /// </summary>
    public virtual string ToolTip { get; init; } = string.Empty;

    /// <summary>
    /// 动作描述
    /// </summary>
    public virtual string Description { get; init; } = string.Empty;

    /// <summary>
    /// 动作图标
    /// </summary>
    public virtual IImage? Icon { get; init; }

    /// <summary>
    /// 动作是否可以执行
    /// </summary>
    public bool CanRun { get; set; } = true;

    /// <summary>
    /// 动作是否可以执行发生变化时触发的事件
    /// </summary>
    public EventHandler? CanRunChanged { get; set; }

    /// <summary>
    /// 执行动作
    /// </summary>
    /// <returns>
    /// 返回一个异步任务
    /// </returns>
    public abstract Task Run();
}