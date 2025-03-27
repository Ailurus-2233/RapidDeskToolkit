using Avalonia.Controls;

using RapidDeskToolkit.UIDemo.Resources;

namespace RapidDeskToolkit.UIDemo.Pages;

public partial class OverviewPage : UserControl, IPage
{
    public OverviewPage()
    {
        DataContext = this;
        InitializeComponent();
    }

    public string Title => Language.OverviewPageName;

    public UserControl GetUserControl() => this;

    public string NeedProjects => "RapidDeskToolkit\nRapidDeskToolkit.UIPackage";

    public string StylesName => "<Styles>\n\t...\n\t<uiPackage:Generic />\n\t...\n</Styles>";
}
