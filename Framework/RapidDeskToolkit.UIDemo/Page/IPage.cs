using Avalonia.Controls;

namespace RapidDeskToolkit.UIDemo.Page;

public interface IPage
{
    public string Title { get; }
    
    public UserControl? GetUserControl();
}
