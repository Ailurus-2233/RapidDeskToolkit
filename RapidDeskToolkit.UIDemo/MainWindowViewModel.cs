using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RapidDeskToolkit.Common.ResourceLoader;
using RapidDeskToolkit.UIDemo.Page;
using RapidDeskToolkit.UIDemo.Pages;
using RapidDeskToolkit.UIDemo.Resources;

namespace RapidDeskToolkit.UIDemo;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]
    private string _header = string.Empty;

    [ObservableProperty]
    private ObservableCollection<IPage> _pages =
    [
        new OverviewPage(),
    ];

    [ObservableProperty]
    private IPage? _selectedPage;

    [ObservableProperty]
    private UserControl? _selectedControl;
    
    partial void OnSelectedPageChanged(IPage? value)
    {
        SelectedControl = value?.GetUserControl();
    }

    [RelayCommand]
    public void OnLoadedCommand()
    {
        Header = Language.WindowTitleName;
    }
}