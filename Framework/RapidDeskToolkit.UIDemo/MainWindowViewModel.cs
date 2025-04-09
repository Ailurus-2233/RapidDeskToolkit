using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Markup.Xaml.MarkupExtensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RapidDeskToolkit.Common.Container;
using RapidDeskToolkit.UIDemo.Pages;
using RapidDeskToolkit.UIDemo.Pages.ViewModels;

namespace RapidDeskToolkit.UIDemo;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<IPage> _pages =
    [];

    [ObservableProperty]
    private IPage? _selectedPage;

    [ObservableProperty]
    private UserControl? _selectedControl;

    public string Header =>
        Resources.LangKeys.MainWindow_Title + (SelectedPage is null ? string.Empty : $" - {SelectedPage.Title}");

    private static readonly string[] SupportedLanguages = ["en", "zh-CN"];
    private static int LanguageIndex;

    public MainWindowViewModel()
    {
        SelectedPage = Pages.FirstOrDefault();
        var culture = CultureInfo.CurrentCulture;
        LanguageIndex = Array.IndexOf(SupportedLanguages, culture.Name);
    }

    partial void OnSelectedPageChanged(IPage? value)
    {
        SelectedControl = value?.GetUserControl();
        OnPropertyChanged(nameof(Header));
    }

    [RelayCommand]
    public void OnLoadedCommand()
    {
        Pages.Add(IoC.GetInstance<OverviewPageViewModel>()!);
        OnPropertyChanged(nameof(Header));
    }


    [RelayCommand]
    public void ChangeLanguage()
    {
        LanguageIndex = (LanguageIndex + 1) % SupportedLanguages.Length;
        var culture = new CultureInfo(SupportedLanguages[LanguageIndex]);
        I18NExtension.Culture = culture;
        CultureInfo.CurrentCulture = culture;
    }
}
