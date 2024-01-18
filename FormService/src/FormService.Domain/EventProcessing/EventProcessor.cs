using System.Text.Json;
using AutoMapper;
using FormService.Domain.Dtos;
using FormService.Domain.Dtos.WorkspaceDtos;
using FormService.Domain.Enums;
using FormService.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FormService.Domain.EventProcessing;

public class EventProcessor(IServiceScopeFactory serviceScopeFactory, IMapper mapper) : IEventProcessor
{
    public async void ProcessEvent(string message)
    {
        var eventType = DetermineEvent(message);

        switch (eventType)
        {
            case EventType.WorkspacePublished:
                await AddWorkspace(message);
                break;
            
            case EventType.Undetermined:
                Console.WriteLine("Undetermined event");
                break;
        }
    }

    private async Task AddWorkspace(string workspacePublishedMessage)
    {
        using var scope = serviceScopeFactory.CreateScope();
        var repository = scope.ServiceProvider.GetRequiredService<IWorkspaceService>();
        var workspacePublishedDto = JsonSerializer.Deserialize<PublishedWorkspaceDto>(workspacePublishedMessage);

        try
        {
            if (!await repository.WorkspacesExistAsync(workspacePublishedDto.Id))
            {
                await repository.CreateWorkspaceAsync(workspacePublishedDto);
            }
            else
            {
                Console.WriteLine("Workspace already exists");
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Error creating workspace, details: {exception.Message}");
        }
    }

    private EventType DetermineEvent(string notificationMessage)
    {
        var eventType = JsonSerializer.Deserialize<GenericEventDto>(notificationMessage);

        return eventType?.Event switch
        {
            "Workspace_Published" => EventType.WorkspacePublished,
            _ => EventType.Undetermined
        };
    }
}
