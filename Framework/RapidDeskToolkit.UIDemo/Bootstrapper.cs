using System.Globalization;
using RapidDeskToolkit.Common.Bootstrapper;
using RapidDeskToolkit.UIDemo.Resources;

namespace RapidDeskToolkit.UIDemo;

public class Bootstrapper : BaseBootstrapper<App, MainWindow>
{
    public override void Initialize()
    {
        base.Initialize();
        Language.Culture = CultureInfo.CurrentCulture;
    }
}