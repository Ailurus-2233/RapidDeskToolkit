﻿using A6ToolKits;
using A6ToolKits.Bootstrapper;
using A6ToolKits.Layout;
using A6ToolKits.Module;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Themes.Fluent;

namespace A6Application;

/// <summary>
///     启动类
/// </summary>
public class AppBootstrapper : BaseBootstrapper<BaseApp, Window>
{
    /// <summary>
    ///     重写完成方法，在完成时设置主窗体
    /// </summary>
    public override void OnCompleted()
    {
        if (ModuleLoader.TryGetModule<LayoutModule>(out var layoutModule))
        {
            MainWindow = layoutModule?.WindowLayout?.WindowContainer;
        }
        // MainWindow = IoC.Get<MainWindow>();
        base.OnCompleted();
    }
}