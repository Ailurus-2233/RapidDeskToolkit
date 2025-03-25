namespace RapidDeskToolkit.Desktop.Configs;

/// <summary>
///     控件配置项
/// </summary>
public static class ThemeConfig
{
    /// <summary>
    ///     窗口重点色
    /// </summary>
    public static string PrimaryColor { get; set; } = "#6495ED";

    /// <summary>
    ///     窗口背景色
    /// </summary>
    public static string BackgroundColor { get; set; } = "#FFFFFF";

    /// <summary>
    ///     菜单栏高度
    /// </summary>
    public static double MenuHeight { get; set; } = 30;

    /// <summary>
    ///     状态栏高度
    /// </summary>
    public static double StatusBarHeight { get; set; } = 30;

    /// <summary>
    ///     工具栏高度
    /// </summary>
    public static double ToolBarHeight { get; set; } = 30;

    /// <summary>
    ///     标题栏高度，仅在 Default 布局下生效
    /// </summary>
    public static double TitleBarHeight { get; set; } = 30;
}