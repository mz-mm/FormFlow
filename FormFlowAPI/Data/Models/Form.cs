namespace FormFlowApi.Data.Models;

public class Form
{
    public const int MaxFormNameLength = 30;
    public const int MinFormNameLength = 3;
    
    public const int MaxFormDescriptionLength = 30;
    public const int MinFormDescriptionLength = 30;

    public const int MaxFormSubmissionCount = 1000;
    
    public string Id { get; set; }
    public string FormName { get; set; }
    public string FormDescription { get; set; }
    public bool IsSubmissionOpen { get; set; }
    public int FormSubmissionLimit { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public DateTime CreatedAt { get; set; }
    public string EventManagerId { get; set; }
    public EventManager EventManager { get; set; }
    public List<FormQuestion> FormQuestions { get; set; }

    
    private Form() { }

    private Form(Guid id, Guid eventManagerId, string formName, string formDescription, bool isSubmissionOpen, int formSubmissionLimit, DateTime startDateTime, DateTime endDateTime, DateTime createdAt)
    {
        Id = id.ToString();
        EventManagerId = eventManagerId.ToString();
        FormName = formName;
        FormDescription = formDescription;
        IsSubmissionOpen = false;
        FormSubmissionLimit = formSubmissionLimit;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        CreatedAt = createdAt;
    }

    public static Form Create(Guid eventManagerId, string formName, string? formDescription = null, bool isSubmissionOpen = true, int? formSubmissionLimit = MaxFormSubmissionCount, DateTime? startDateTime = null, DateTime? endDateTime = null, Guid? id = null, DateTime? createdAt = null)
    {
        if (formName.Length is < MinFormNameLength or > MaxFormNameLength || string.IsNullOrWhiteSpace(formName))
            throw new AggregateException("Invalid form name length or form name is invalid format");
        
        if (formDescription?.Length is < MinFormDescriptionLength or > MaxFormDescriptionLength)
            throw new AggregateException("Invalid form description length.");
        
        if (startDateTime > endDateTime)
            throw new ArgumentException("Invalid Start date and End date");

        return new Form(
            id ?? Guid.NewGuid(),
            eventManagerId,
            formName,
            formDescription ?? "",
            isSubmissionOpen,
            formSubmissionLimit ?? MaxFormSubmissionCount,
            startDateTime ?? DateTime.UtcNow,
            endDateTime ?? DateTime.MaxValue,
            createdAt ?? DateTime.UtcNow
            );
    }
}
