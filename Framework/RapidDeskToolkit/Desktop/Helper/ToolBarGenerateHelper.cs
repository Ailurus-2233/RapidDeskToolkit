﻿using System.Reflection;
using A6ToolKits.Container;
using A6ToolKits.Controls.Controls.Command;
using A6ToolKits.Layout.Generator;
using Avalonia.Controls;
using RapidDeskToolkit.AssemblyHandler;
using RapidDeskToolkit.Container;
using RapidDeskToolkit.Desktop.Attributes;
using RapidDeskToolkit.Desktop.Exceptions;

namespace A6ToolKits.Layout.Helper;

/// <summary>
///     工具栏生成工具
/// </summary>
internal static class ToolBarGenerateHelper
{
    private static WindowConfig _config { get; } = WindowConfig.Instance;
    private static WindowGenerator _generator { get; set; } = WindowGenerator.Instance;

    /// <summary>
    ///     获取类的 MenuActionAttribute 属性
    /// </summary>
    /// <param name="type" cerf="Type"> 目标类 </param>
    /// <returns cref="MenuActionAttribute"> MenuActionAttribute 对象 </returns>
    /// <exception cref="TypeNotFoundException"> </exception>
    public static ToolBarActionAttribute GetToolBarActionAttribute(this Type type)
    {
        ArgumentNullException.ThrowIfNull(type);
        var attribute = type.GetCustomAttribute<ToolBarActionAttribute>();
        if (attribute == null) throw new AttributeNotFoundException(type, typeof(ToolBarActionAttribute));
        return attribute;
    }

    /// <summary>
    ///     获取所有有ToolBar属性的ActionBase类
    /// </summary>
    public static List<IGrouping<int?, Type>> GetToolBarGroup()
    {
        var types = SimpleAssemblyHandler.GetTypeWithAttribute<ToolBarActionAttribute>();
        var groups = types.GroupBy(t => t.GetCustomAttribute<ToolBarActionAttribute>()?.Group)
            .OrderBy(group => group.Key).ToList();
        return groups;
    }

    /// <summary>
    ///     根据类型生成一组按钮
    /// </summary>
    /// <param name="types">
    ///     一些继承了ActionBase的类
    /// </param>
    /// <returns>
    ///     按钮列表
    /// </returns>
    public static List<Button> GenerateButtons(List<Type> types)
    {
        var result = new List<Button>();
        types.ForEach(type =>
        {
            if (!typeof(CommandControl).IsAssignableFrom(type))
                throw new IncorrectlyClassException(type, typeof(CommandControl));
            var obj = IoC.Create(type);
            if (obj is not CommandControl action) return;
            var buttonType = type.GetToolBarActionAttribute().Type;
            var button = action.GenerateButton(buttonType, _config.ToolBarHeight);
            result.Add(button);
        });
        return result;
    }

    /// <summary>
    ///     生成工具栏中的所有子控件 按钮+分割线
    /// </summary>
    /// <returns>
    ///     子控件列表
    /// </returns>
    public static List<Control> GenerateToolBarItems()
    {
        var result = new List<Control>();
        var groups = GetToolBarGroup();
        if (groups.Count == 0) return result;
        groups.ForEach(group =>
        {
            var buttons = GenerateButtons(group.ToList());
            result.AddRange(buttons);
            result.Add(new Separator
            {
                Width = 1,
                Height = double.NaN
            });
        });

        if (result.Count > 0)
            result.RemoveAt(result.Count - 1);
        return result;
    }
}