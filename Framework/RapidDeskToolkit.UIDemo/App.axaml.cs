using Avalonia;
using Avalonia.Markup.Xaml;

namespace RapidDeskToolkit.UIDemo;

public class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }
}
