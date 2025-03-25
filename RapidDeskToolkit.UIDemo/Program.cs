using Avalonia;
using System;

namespace RapidDeskToolkit.UIDemo;

class Program
{
    private static readonly Bootstrapper Bootstrapper = new();
    
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args) => Bootstrapper.Run(args);

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => Bootstrapper.InitialAppBuilder();
}