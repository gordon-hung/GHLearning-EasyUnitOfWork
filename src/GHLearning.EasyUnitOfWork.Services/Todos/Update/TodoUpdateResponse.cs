namespace GHLearning.EasyUnitOfWork.Services.Todos.Update;

public record TodoUpdateResponse(
    int Id,
    string Title,
    string Description,
    DateTimeOffset CreatedAt,
    DateTimeOffset UpdatedAt);