using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using RapidDeskToolkit.UIDemo.Pages;

namespace RapidDeskToolkit.UIDemo.ViewModels;

public partial class PageSelectorViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<IPage> _pages = [
        new OverviewPage()
    ];
    
    [ObservableProperty]
    private IPage _selectedPage = null!;
    
    [ObservableProperty]
    private string _text = Language.OverviewPageTitle;

    [ObservableProperty]
    private List<string> _textSource = [
        "test1", "test2", "test3"
    ];
}