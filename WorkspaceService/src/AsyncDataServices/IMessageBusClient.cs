using src.Dtos;

namespace src.AsyncDataServices;

public interface IMessageBusClient
{
    public void PublishNewWorkspace(PublishWorkspaceDto publishWorkspaceDto);
}
