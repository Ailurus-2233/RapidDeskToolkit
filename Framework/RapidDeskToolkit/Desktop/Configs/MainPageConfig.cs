using System.Reflection;

namespace RapidDeskToolkit.Desktop.Configs;

/// <summary>
///     主页配置项
/// </summary>
public static class MainPageConfig
{
    /// <summary>
    ///     目标类型
    /// </summary>
    public static string TargetType { get; set; } = string.Empty;
    
    /// <summary>
    ///     获取目标页面类型
    /// </summary>
    /// <returns>
    ///     目标页面类型
    /// </returns>
    public static Type FindTargetType()
    {
        var assembly = Assembly.GetEntryAssembly();
        return assembly?.GetType(TargetType);
    }
}