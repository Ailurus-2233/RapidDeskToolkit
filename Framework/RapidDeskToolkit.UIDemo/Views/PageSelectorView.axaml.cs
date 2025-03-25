using Avalonia.Controls;
using RapidDeskToolkit.UIDemo.ViewModels;

namespace RapidDeskToolkit.UIDemo.Views;

public partial class PageSelectorView : UserControl
{
    public PageSelectorView()
    {
        DataContext = new PageSelectorViewModel();
        InitializeComponent();
    }
}