using A6ToolKits.Container;
using A6ToolKits.Controls.Controls.Command;
using Avalonia.Media;
using RapidDeskToolkit.ApplicationController;
using RapidDeskToolkit.Common.ResourceLoader;
using RapidDeskToolkit.Container;

namespace A6ToolKits.Layout.Controls.ControlCommand;

/// <summary>
///     关闭 Command
/// </summary>
public sealed class CloseCommand : CommandControl
{
    /// <inheritdoc />
    public override string Text => "关闭程序";

    /// <inheritdoc />
    public override string ToolTip => "关闭程序";

    /// <inheritdoc />
    public override IImage? Image { get; } = ResourceHelper.LoadImage("CloseIcon");

    /// <inheritdoc />
    public override Task Run()
    {
        var window = IoC.GetInstance<IApplicationController>()?.MainWindow;
        window?.Close();
        return Task.CompletedTask;
    }
}
