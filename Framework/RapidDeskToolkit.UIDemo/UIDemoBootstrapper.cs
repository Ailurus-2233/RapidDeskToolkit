using System.Globalization;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Styling;
using RapidDeskToolkit.Common.Bootstrapper;
using Ursa.Themes.Semi;

namespace RapidDeskToolkit.UIDemo;

public class UIDemoBootstrapper : BaseBootstrapper<UIDemoApp, MainWindow>
{
    public override void Configure()
    {
        base.Configure();
        // 获取系统语言，并配置Language类
        var language = CultureInfo.CurrentCulture.Name;
        Language.Culture = CultureInfo.GetCultureInfo(language);
    }
}