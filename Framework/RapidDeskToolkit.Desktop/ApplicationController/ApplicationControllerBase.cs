using System.Diagnostics;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Styling;

namespace RapidDeskToolkit.Desktop.ApplicationController;

public abstract class ApplicationControllerBase<TApplication, TWindow> : IApplicationController
    where TApplication : Application, new()
    where TWindow : Window, new()
{
    private AppBuilder? _appBuilder;
    private ClassicDesktopStyleApplicationLifetime? _lifetime;
    private string[]? _runArguments;

    public Window? MainWindow { get; set; }
    public ThemeVariant Theme { get; set; } = ThemeVariant.Default;

    public virtual void Run(string[]? args)
    {
        _runArguments = args;
        InitialAppBuilder();
        Initialize();
        MainWindow = new TWindow();
    }

    public virtual void StopApplication()
    {
        _lifetime?.Shutdown();
    }

    public virtual void StartApplication()
    {
        if (_lifetime == null) return;
        if (MainWindow == null) return;
        _lifetime.MainWindow = MainWindow;
        if (Debugger.IsAttached)
            MainWindow.AttachDevTools();
        _lifetime?.Start(_runArguments ?? []);
    }

    private void Initialize()
    {
        _lifetime = DesktopLifetimeExtension.PrepareLifetime(_appBuilder, _runArguments ?? [], null);
        _appBuilder?.SetupWithLifetime(_lifetime);
    }

    public virtual AppBuilder? InitialAppBuilder()
    {
        // 如果是 Debug 模式，则启用Avalonia的日志记录
        if (Debugger.IsAttached)
            _appBuilder = AppBuilder
                .Configure<TApplication>()
                .UsePlatformDetect()
                .LogToTrace();
        else
            _appBuilder = AppBuilder
                .Configure<TApplication>()
                .UsePlatformDetect();
        return _appBuilder;
    }
}
