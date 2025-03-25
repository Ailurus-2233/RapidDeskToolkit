using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RapidDeskToolkit.Models.Commands;

public class CommandDefinition : INotifyPropertyChanged
{
    private string _text = string.Empty;
    private string _tooltip = string.Empty;
    private string _imageKey = string.Empty;
    private string _imageUrl = string.Empty;

    public string Text
    {
        get => _text;
        set => SetField(ref _text, value);
    }
    
    public string ToolTip
    {
        get => _tooltip;
        set => SetField(ref _tooltip, value);
    }
    
    public string ImageKey
    {
        get => _imageKey;
        set => SetField(ref _imageKey, value);
    }

    public string ImageUrl
    {
        get => _imageUrl;
        set => SetField(ref _imageUrl, value);
    }
    
    
    #region INotifyPropertyChanged

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }

    #endregion
}