namespace GHLearning.EasyUnitOfWork.Repositories.Todos.Dtos;

public record TodoDto(
    int Id,
    string Title,
    string Description,
    DateTimeOffset CreatedAt,
    DateTimeOffset UpdatedAt);
