using Avalonia.Controls;

namespace RapidDeskToolkit.UIDemo;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        DataContext = new MainWindowViewModel();
        InitializeComponent();
    }
}