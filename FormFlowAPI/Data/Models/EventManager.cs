using Microsoft.AspNetCore.Identity;

namespace FormFlowApi.Data.Models;

public class EventManager
{
    public const int MaxEventNameLength = 30;
    public const int MinEventNameLength = 3;

    public const int MaxEventDescriptionLength = 30;
    public const int MinEventDescriptionLength = 3;

    public const uint MaxFormLimits = 20;

    public string Id { get; set; }
    public string EventName { get; set; }
    public string EventDescription { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public bool IsRegistrationOpen { get; set; }
    public DateTime CreatedAt { get; set; }
    public string WorkspaceId { get; set; }
    public Workspace Workspace { get; set; }
    public List<Form> Forms { get; set; }


    private EventManager()
    {
    }

    private EventManager(Guid id, Guid workspaceId, string eventName, string eventDescription, DateTime startDateTime,
        DateTime endDateTime, bool isRegistrationOpen, DateTime createdAt)
    {
        Id = id.ToString();
        WorkspaceId = workspaceId.ToString();
        EventName = eventName;
        EventDescription = eventDescription;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        IsRegistrationOpen = isRegistrationOpen;
        CreatedAt = createdAt;
    }

    public static EventManager Create(Guid workspaceId, string eventName, Guid? id = null, string? eventDescription = null,
        DateTime? startDateTime = null, DateTime? endDateTime = null, bool isRegistrationOpen = false,
        DateTime? createdAt = null)
    {
        if (eventName.Length is < MinEventNameLength or > MaxEventNameLength || string.IsNullOrWhiteSpace(eventName))
            throw new AggregateException("Invalid event name length or event name is invalid");

        if (eventDescription?.Length is < MinEventDescriptionLength or > MaxEventDescriptionLength)
            throw new AggregateException("Invalid event name length.");

        if (startDateTime > endDateTime)
            throw new ArgumentException("Invalid Start date and End date");

        return new EventManager(
            id ?? Guid.NewGuid(),
            workspaceId,
            eventName,
            eventDescription ?? "",
            startDateTime ?? DateTime.UtcNow,
            endDateTime ?? DateTime.MaxValue,
            isRegistrationOpen,
            createdAt ?? DateTime.UtcNow
        );
    }
}
