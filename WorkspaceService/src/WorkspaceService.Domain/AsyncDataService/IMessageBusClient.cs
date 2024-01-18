using WorkspaceService.Domain.Dtos;

namespace WorkspaceService.Domain.AsyncDataService;

public interface IMessageBusClient
{
    public void PublishNewWorkspace(PublishWorkspaceDto publishWorkspaceDto);
}
