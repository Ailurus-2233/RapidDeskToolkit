using RapidDeskToolkit.Models.Events;

namespace RapidDeskToolkit.Common.EventAggregator;

public interface IHandler<in TEvent> where TEvent : FrameworkEventBase
{
    void Handle(TEvent e);
}