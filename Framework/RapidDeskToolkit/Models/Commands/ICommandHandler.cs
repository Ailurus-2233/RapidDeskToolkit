namespace RapidDeskToolkit.Models.Commands;

public interface ICommandHandler
{
    Task Run();
}