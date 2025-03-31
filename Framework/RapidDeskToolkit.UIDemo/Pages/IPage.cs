using Avalonia.Controls;

namespace RapidDeskToolkit.UIDemo.Pages;

public interface IPage
{
    public string Title { get; }
    
    public UserControl? GetUserControl();
}
