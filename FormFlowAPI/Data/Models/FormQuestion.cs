namespace FormFlowApi.Data.Models;

public class FormQuestion
{
    public const int MaxQuestionLength = 30;
    public const int MinQuestionLength = 3;

    public string Id { get; set; }
    public string Question { get; set; }
    public string QuestionType { get; set; }
    public DateTime CreatedAt { get; set; }
    public string FormId { get; set; }
    public Form Form { get; set; }

    private FormQuestion()
    {
    }

    private FormQuestion(Guid id, Guid formId, string question, string questionType, DateTime createdAt)
    {
        Id = id.ToString();
        FormId = formId.ToString();
        QuestionType = questionType;
        Question = question;
        CreatedAt = createdAt;
    }

    public static FormQuestion Create(Guid formId, string question, string questionType, Guid? id = null,
        DateTime? dateTime = null)
    {
        if (question.Length is < MinQuestionLength or > MaxQuestionLength || string.IsNullOrWhiteSpace(question))
            throw new ArgumentException("Invalid question length or question is invalid format.");

        if (string.IsNullOrWhiteSpace(questionType)) throw new AggregateException("Invalid question type format.");

        return new FormQuestion(
            id ?? Guid.NewGuid(),
            formId,
            question,
            questionType,
            dateTime ?? DateTime.UtcNow
        );
    }
}
