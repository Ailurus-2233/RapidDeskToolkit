namespace RapidDeskToolkit.Models.Commands;

public abstract class CommandBase : CommandDefinition
{
    private bool _isEnabled = true;
    private bool _isVisible = true;

    public bool IsEnabled
    {
        get => _isEnabled;
        set => SetField(ref _isEnabled, value);
    }

    public bool IsVisible
    {
        get => _isVisible;
        set => SetField(ref _isVisible, value);
    }

    public abstract Task Run();
}