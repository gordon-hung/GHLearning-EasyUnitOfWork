namespace GHLearning.EasyUnitOfWork.Services.Todos.Query;

public record TodoQueryResponse(
    int Id,
    string Title,
    string Description,
    DateTimeOffset CreatedAt,
    DateTimeOffset UpdatedAt);
