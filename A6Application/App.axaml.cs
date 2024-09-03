using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using A6Application.ViewModels;
using A6Application.Views;
using A6ToolKits.MVVM.Common;

namespace A6Application;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }
}