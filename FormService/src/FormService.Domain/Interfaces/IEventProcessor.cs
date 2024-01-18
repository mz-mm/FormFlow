namespace FormService.Domain.Interfaces;

public interface IEventProcessor
{
    public void ProcessEvent(string message);
}
