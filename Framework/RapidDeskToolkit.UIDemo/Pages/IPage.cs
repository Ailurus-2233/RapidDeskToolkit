using Avalonia.Controls;

namespace RapidDeskToolkit.UIDemo.Pages;

public interface IPage
{
    public string Title { get; set; }

    public UserControl Content
    {
        get
        {
            // ReSharper disable once SuspiciousTypeConversion.Global
            if (this is not UserControl result)
                throw new InvalidOperationException("IPage must be implemented by a UserControl");
            return result;
        }
    }
}