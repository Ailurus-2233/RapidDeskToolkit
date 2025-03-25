using A6ToolKits.Container;
using A6ToolKits.Controls.Controls.Command;
using Avalonia.Controls;
using Avalonia.Media;
using RapidDeskToolkit.ApplicationController;
using RapidDeskToolkit.Common.ResourceLoader;
using RapidDeskToolkit.Container;

namespace A6ToolKits.Layout.Controls.ControlCommand;

/// <summary>
///     最大化 Command
/// </summary>
public sealed class MaximizeCommand : CommandControl
{
    /// <inheritdoc />
    public override string Text => "最大化";

    /// <inheritdoc />
    public override string ToolTip => "最大化";

    /// <inheritdoc />
    public override IImage? Image { get; } = ResourceHelper.LoadImage("MaximizeIcon");

    public override Task Run()
    {
        var window = IoC.GetInstance<IApplicationController>()?.MainWindow;
        if (window is null) return Task.CompletedTask;
        window.WindowState = WindowState.Maximized;
        return Task.CompletedTask;
    }
}