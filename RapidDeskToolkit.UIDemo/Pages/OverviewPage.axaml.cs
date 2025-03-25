using Avalonia.Controls;
using RapidDeskToolkit.UIDemo.Page;
using RapidDeskToolkit.UIDemo.Resources;

namespace RapidDeskToolkit.UIDemo.Pages;

public partial class OverviewPage : UserControl, IPage
{
    public OverviewPage()
    {
        InitializeComponent();
    }

    public string Title => Language.OverviewPageName;

    public UserControl GetUserControl() => this;
}