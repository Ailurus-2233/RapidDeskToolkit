﻿using A6ToolKits.Bootstrapper;
using A6ToolKits.Common.Attributes;
using A6ToolKits.Common.Container;
using A6ToolKits.Layout.Generator;
using A6ToolKits.Module;
using Avalonia;
using Avalonia.Markup.Xaml.Styling;
using Avalonia.Styling;

namespace A6ToolKits.Layout;

/// <summary>
///     布局模块，如果加载该模块将会基于配置文件自动加载窗口
/// </summary>
[AutoRegister(typeof(ILayoutModule), RegisterType.Singleton)]
public sealed class LayoutModule : ModuleBase<LayoutConfigItem>, ILayoutModule
{
    private static WindowGenerator _generator => WindowGenerator.Instance;
    
    /// <summary>
    ///     Layout 模块的配置项
    /// </summary>
    protected override LayoutConfigItem Config { get; } = new();

    /// <summary>
    ///     初始化布局模块，加载布局配置文件
    /// </summary>
    public override void Initialize()
    {
        LoadResource();
        SetMainWindow();
    }

    /// <summary>
    ///     设置主窗口
    /// </summary>
    public void SetMainWindow()
    {
        var controller = IoC.GetInstance<IWindowController>();
        if (controller != null)
        {
            controller.SetupMainWindow(_generator.GenerateWindow(Config));
            controller.SetupTheme(WindowConfig.Instance.Theme);
        }
        else
        {
            throw new NullReferenceException("Cannot get window controller");
        }
    }

    private void LoadResource()
    {
        var resUri = new Uri("avares://A6ToolKits.Layout/Resources/LayoutResources.axaml");
        var resource = new ResourceInclude(resUri)
        {
            Source = resUri
        };
        Application.Current?.Resources.MergedDictionaries.Add(resource);
    }
}