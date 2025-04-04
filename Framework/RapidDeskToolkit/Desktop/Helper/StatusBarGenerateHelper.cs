﻿using System.Reflection;
using A6ToolKits.Container;
using A6ToolKits.Layout.Generator;
using Avalonia.Controls;
using RapidDeskToolkit.AssemblyHandler;
using RapidDeskToolkit.Container;
using RapidDeskToolkit.Desktop.Attributes;
using RapidDeskToolkit.Desktop.Exceptions;

namespace A6ToolKits.Layout.Helper;

/// <summary>
///     状态栏生成工具类
/// </summary>
internal static class StatusBarGenerateHelper
{
    private static WindowConfig _config { get; set; } = WindowConfig.Instance;
    private static WindowGenerator _generator { get; set; } = WindowGenerator.Instance;

    /// <summary>
    ///     获取所有有StatusBar属性的ActionBase类
    /// </summary>
    /// <returns></returns>
    public static List<Type> GetStatusBarTypes(StatusPosition position)
    {
        var types = SimpleAssemblyHandler.GetTypeWithAttribute<StatusBarItemAttribute>();
        return types.Where(t => t.GetStatusBarItemAttribute().Position == position).ToList();
    }

    /// <summary>
    ///     获取类的 MenuActionAttribute 属性
    /// </summary>
    /// <param name="type" cerf="Type"> 目标类 </param>
    /// <returns cref="MenuActionAttribute"> MenuActionAttribute 对象 </returns>
    /// <exception cref="TypeNotFoundException"> </exception>
    public static StatusBarItemAttribute GetStatusBarItemAttribute(this Type type)
    {
        ArgumentNullException.ThrowIfNull(type);
        var attribute = type.GetCustomAttribute<StatusBarItemAttribute>();
        if (attribute == null) throw new AttributeNotFoundException(type, typeof(StatusBarItemAttribute));
        return attribute;
    }

    /// <summary>
    ///     生成状态栏控件列表
    /// </summary>
    /// <param name="position">
    ///     状态栏区域
    /// </param>
    /// <returns>
    ///     控件列表
    /// </returns>
    public static List<Control> GenerateStatusBarItems(StatusPosition position)
    {
        var result = new List<Control>();
        var types = GetStatusBarTypes(position);

        types.ForEach(type =>
        {
            var obj = IoC.Create(type);
            if (obj is not Control control) return;
            result.Add(control);
        });

        return result;
    }
}