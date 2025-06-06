﻿namespace RapidDeskToolkit.Common.DatabaseManager.Configs;

/// <summary>
///     数据库配置项基类
/// </summary>
public abstract class DatabaseConfigItemBase
{
    /// <summary>
    ///     数据库名称
    /// </summary>
    public abstract string Name { get; set; }

    /// <summary>
    ///    根据配置构建数据库管理器
    /// </summary>
    /// <returns>
    ///     数据库管理器
    /// </returns>
    public abstract ManagerBase GenerateManager();
}