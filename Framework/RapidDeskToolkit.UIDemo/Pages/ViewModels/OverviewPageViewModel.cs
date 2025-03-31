using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using RapidDeskToolkit.Common.Container;
using RapidDeskToolkit.Common.Container.Attributes;
using RapidDeskToolkit.Common.LanguageManager;
using RapidDeskToolkit.UIDemo.Pages.Views;

namespace RapidDeskToolkit.UIDemo.Pages.ViewModels;

[TargetView(typeof(OverviewPage))]
public class OverviewPageViewModel : ObservableObject, IPage
{
    public OverviewPageViewModel()
    {
        LanguageManager.LanguageChanged += NotifyAllProperties;
    }

    public string Title => LanguageManager.GetString("OverviewPageTitle");

    public UserControl? GetUserControl() => IoC.GetInstance<OverviewPage>();

    public string Description => LanguageManager.GetString("OverviewDescriptionParagraph1") +
                                 LanguageManager.GetString("OverviewDescriptionParagraph2");

    public string HowToUse => LanguageManager.GetString("OverviewPage_Content_HowToUse");

    public string AddDependencies => LanguageManager.GetString("OverviewPage_Content_AddDependencies");

    public string LoadStyles => LanguageManager.GetString("OverviewPage_Content_LoadStyles");

    public string NeedProjects => "RapidDeskToolkit\nRapidDeskToolkit.UIPackage";

    public string StylesName => "<!-- App.axaml -->\n<Styles>\n\t...\n\t<uiPackage:Generic />\n\t...\n</Styles>";

    public string Example => LanguageManager.GetString("OverviewPage_Content_Example");

    private void NotifyAllProperties()
    {
        OnPropertyChanged(nameof(Title));
        OnPropertyChanged(nameof(Description));
        OnPropertyChanged(nameof(HowToUse));
        OnPropertyChanged(nameof(AddDependencies));
        OnPropertyChanged(nameof(LoadStyles));
        OnPropertyChanged(nameof(NeedProjects));
        OnPropertyChanged(nameof(StylesName));
        OnPropertyChanged(nameof(Example));
    }
}
