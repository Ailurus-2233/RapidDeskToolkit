namespace RapidDeskToolkit.Desktop.Configs;

/// <summary>
///     窗口配置项
/// </summary>
public static class WindowConfig
{
    /// <summary>
    ///     窗口标题
    /// </summary>
    public static string Title { get; set; } = "A6ToolKit-Application";

    /// <summary>
    ///     窗口边框样式，可选值：Default、Origin、None
    /// </summary>
    public static BorderStyle BorderStyle { get; set; } = BorderStyle.Default;
    
    /// <summary>
    ///     窗口类型，可选值：Default、Maximized、FullScreen
    /// </summary>
    public static WindowType WindowType { get; set; } = WindowType.Default;

    /// <summary>
    ///     窗口宽度
    /// </summary>
    public static double Width { get; set; } = 800;

    /// <summary>
    ///     窗口高度
    /// </summary>
    public static double Height { get; set; } = 600;

    /// <summary>
    ///     窗口图标
    /// </summary>
    public static string IconUrl { get; set; } = "";
}

public enum WindowType
{
    Default,
    Maximized,
    FullScreen
}

public enum BorderStyle
{
    Default,
    Origin,
    None
}