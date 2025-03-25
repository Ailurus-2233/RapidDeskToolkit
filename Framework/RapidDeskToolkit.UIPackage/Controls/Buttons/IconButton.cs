using Avalonia;
using Avalonia.Data;
using Avalonia.Media;

namespace RapidDeskToolkit.UIPackage.Controls.Buttons;

public class IconButton : Avalonia.Controls.Button
{
    public static readonly StyledProperty<string> ImageKeyProperty =
        AvaloniaProperty.Register<IconButton, string>(nameof(ImageKey), defaultBindingMode: BindingMode.TwoWay);

    public static readonly StyledProperty<string> ImageUrlProperty =
        AvaloniaProperty.Register<IconButton, string>(nameof(ImageUrl), defaultBindingMode: BindingMode.TwoWay);

    public static readonly StyledProperty<string> TextProperty =
        AvaloniaProperty.Register<IconButton, string>(nameof(Text), defaultBindingMode: BindingMode.TwoWay);

    public static readonly StyledProperty<string> ToolTipProperty =
        AvaloniaProperty.Register<IconButton, string>(nameof(ToolTip), defaultBindingMode: BindingMode.TwoWay);

    public static readonly StyledProperty<IImage> ImageProperty =
        AvaloniaProperty.Register<IconButton, IImage>(nameof(Image), defaultBindingMode: BindingMode.TwoWay);
    
    public string ImageKey
    {
        get => GetValue(ImageKeyProperty);
        set => SetValue(ImageKeyProperty, value);
    }

    public string ImageUrl
    {
        get => GetValue(ImageUrlProperty);
        set => SetValue(ImageUrlProperty, value);
    }

    public string Text
    {
        get => GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public string ToolTip
    {
        get => GetValue(ToolTipProperty);
        set => SetValue(ToolTipProperty, value);
    }
    
    public IImage Image
    {
        get => GetValue(ImageProperty);
        set => SetValue(ImageProperty, value);
    }

    public IconButton()
    {
        Loaded += (_, _) => { SetButtonSize(); };
    }
    
    private void SetButtonSize()
    {
        var bounds = Bounds;
        Height = bounds.Height;

        if (Classes.Contains("image"))
            Width = Height;

        Padding = new Thickness(Height * 0.1);
    }
}