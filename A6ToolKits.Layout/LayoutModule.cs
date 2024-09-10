using A6ToolKits.Layout.Container;
using A6ToolKits.Layout.Helper;
using A6ToolKits.Module;
using Serilog;

namespace A6ToolKits.Layout;

/// <summary>
///     布局模块，如果加载该模块将会基于配置文件自动加载窗口
/// </summary>
public class LayoutModule : ModuleBase
{
    /// <summary>
    ///     模块名称
    /// </summary>
    public override string ModuleName { get; set; } = "A6ToolKits.Layout";

    /// <summary>
    ///     模块版本
    /// </summary>
    public override string ModuleVersion { get; set; } = "1.0.0";

    /// <summary>
    ///     模块描述
    /// </summary>
    public override string ModuleDescription { get; set; } =
        "Add Layout capabilities to A6ToolKits to automatically load layout for main window";

    /// <summary>
    ///     窗口布局
    /// </summary>
    public WindowLayout? WindowLayout { get; set; }


    /// <summary>
    ///     初始化布局模块，加载布局配置文件
    /// </summary>
    /// <exception cref="Exception">
    ///     布局加载失败
    /// </exception>
    protected override void Initialize()
    {
        Log.Information("Load layout from configuration file");

        WindowLayout = GenerateHelper.LoadLayout();
        if (WindowLayout == null)
            throw new Exception("Failed to load layout configuration");

        Log.Information("Load layout success");
    }
}