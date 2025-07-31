namespace GHLearning.EasyUnitOfWork.Services.Todos.GetById;

public record TodoGetByIdResponse(
    int Id,
    string Title,
    string Description,
    DateTimeOffset CreatedAt,
    DateTimeOffset UpdatedAt);
