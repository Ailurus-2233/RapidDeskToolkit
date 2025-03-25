using RapidDeskToolkit.Models.Events;

namespace RapidDeskToolkit.Common.Bootstrapper.Events;

/// <summary>
///     应用程序退出事件
/// </summary>
public class ApplicationExitEvent: FrameworkEventBase
{
    /// <inheritdoc />
    public override string Message => $"应用程序退出，退出时间：{Time:yyyy-MM-dd HH:mm:ss}";
}