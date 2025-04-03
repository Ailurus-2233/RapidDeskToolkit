using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using RapidDeskToolkit.Common.Container;
using RapidDeskToolkit.Common.Container.Attributes;
using RapidDeskToolkit.UIDemo.Pages.Views;
using RapidDeskToolkit.UIDemo.Resources;

namespace RapidDeskToolkit.UIDemo.Pages.ViewModels;

[TargetView(typeof(OverviewPage))]
public class OverviewPageViewModel : ObservableObject, IPage
{
    public string Title => Language.OverviewPage_Title;
    public UserControl? GetUserControl() => IoC.GetInstance<OverviewPage>();

}
