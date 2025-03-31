using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RapidDeskToolkit.Common.Container;
using RapidDeskToolkit.Common.LanguageManager;
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
        LanguageManager.GetString("WindowTitle") + (SelectedPage is null ? string.Empty : $" - {SelectedPage.Title}");

    private static readonly string[] SupportedLanguages = ["en", "zh-CN"];
    private static int LanguageIndex;

    public MainWindowViewModel()
    {
        SelectedPage = Pages.FirstOrDefault();
        var culture = LanguageManager.GetCurrentCulture();
        LanguageIndex = Array.IndexOf(SupportedLanguages, culture.Name);
        LanguageManager.LanguageChanged += OnLanguageChanged;
    }

    private void OnLanguageChanged()
    {
        NotifyAllProperties();
    }

    partial void OnSelectedPageChanged(IPage? value)
    {
        SelectedControl = value?.GetUserControl();
        NotifyAllProperties();
    }

    [RelayCommand]
    public void OnLoadedCommand()
    {
        Pages.Add(IoC.GetInstance<OverviewPageViewModel>()!);
        NotifyAllProperties();
    }

    private void NotifyAllProperties()
    {
        OnPropertyChanged(nameof(Header));
    }

    [RelayCommand]
    public void ChangeLanguage()
    {
        LanguageIndex = (LanguageIndex + 1) % SupportedLanguages.Length;
        LanguageManager.SetCurrentCulture(new CultureInfo(SupportedLanguages[LanguageIndex]));
    }
}
