using System.Collections.ObjectModel;
using RapidDeskToolkit.UIDemo.Pages;

namespace RapidDeskToolkit.UIDemo.ViewModels.Design;

public class PageSelectorDesignViewModel
{
    public ObservableCollection<IPage> Pages =>
    [
        new OverviewPage()
    ];
    
    public IPage? SelectedPage => null;
}