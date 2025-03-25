using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace RapidDeskToolkit.UIDemo.Pages;

public partial class OverviewPage : UserControl, IPage
{
    public OverviewPage()
    {
        InitializeComponent();
    }

    public string Title { get; set; } = Language.OverviewPageTitle;
}