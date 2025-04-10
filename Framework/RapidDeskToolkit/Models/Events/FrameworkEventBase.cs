namespace RapidDeskToolkit.Models.Events;

/// <summary>
///     事件基类
/// </summary>
public abstract class FrameworkEventBase
{
    protected DateTime Time { get; } = DateTime.Now;
    
    /// <summary>
    ///     用于日志显示的事件内容
    /// </summary>
    public abstract string Message { get; }
}
