using System.Resources;
using RapidDeskToolkit.Common.Bootstrapper;
using RapidDeskToolkit.Common.LanguageManager;

namespace RapidDeskToolkit.UIDemo;

public class Bootstrapper : BaseBootstrapper<App, MainWindow>
{
    public override void Initialize()
    {
        base.Initialize();
        LanguageManager.AddResourceManager(
            new ResourceManager("RapidDeskToolkit.UIDemo.I18n.Language",
                typeof(Bootstrapper).Assembly));
    }
}
