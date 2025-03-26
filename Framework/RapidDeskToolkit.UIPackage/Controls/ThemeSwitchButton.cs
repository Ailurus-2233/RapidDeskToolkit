using Avalonia;
using Avalonia.Controls.Primitives;
using Avalonia.Styling;

namespace RapidDeskToolkit.UIPackage.Controls;

public class ThemeSwitchButton : ToggleButton
{
    public ThemeSwitchButton()
    {
        IsCheckedChanged += (_, _) => OnIsCheckedChanged();
        var app = Application.Current;
        if (app is null) return;
        IsChecked = app.ActualThemeVariant == ThemeVariant.Dark;
    }

    private const double Multiplier = 0.2;

    protected double IconSize
    {
        get => Height * (1 - Multiplier);
    }

    protected double PointTranslated
    {
        get => (Width - IconSize - Height * Multiplier) / 2;
    }

    protected string StartPointTranslated
    {
        get => $"translateX(-{PointTranslated}px)";
    }

    protected string EndPointTranslated
    {
        get => $"translateX({PointTranslated}px)";
    }

    protected Thickness[] CloudMargins
    {
        get =>
        [
            new(0, Height / 2 - 4 * Height * Multiplier, -(Width / 1.2), 0),
            new(0, Height / 2 - 2 * Height * Multiplier, -(Width / 2), 0),
            new(0, Height / 2, -(Width / 1.5), 0),
        ];
    }

    protected Thickness[] CloudHiddenMargins
    {
        get =>
        [
            new(0, Height / 2 - 4 * Height * Multiplier, -Width, 0),
            new(0, Height / 2 - 2 * Height * Multiplier, -Width, 0),
            new(0, Height / 2, -Width, 0),
        ];
    }

    private static readonly Point[] RelativePoint =
    [
        new(0.38, 0.6),
        new(0.53, 0.4),
        new(0.15, 0.3),
        new(0.65, 0.48),
        new(0.34, 0.74),
        new(0.32, 0.26),
        new(0.56, 0.80),
        new(0.11, 0.76),
        new(0.2, 0.86),
        new(0.2, 0.58),
        new(0.51, 0.24),
        new(0.65, 0.4),
        new(0.72, 0.6)
    ];

    protected Point[] StarPoints
    {
        get => RelativePoint.Select(p => new Point(p.X * Width, p.Y * Height)).ToArray();
    }

    private void OnIsCheckedChanged()
    {
        var app = Application.Current;
        if (app is null) return;
        var isDark = IsChecked ?? false;
        app.RequestedThemeVariant = isDark ? ThemeVariant.Dark : ThemeVariant.Light;
    }
}
