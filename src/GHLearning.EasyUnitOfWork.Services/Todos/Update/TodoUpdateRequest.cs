namespace GHLearning.EasyUnitOfWork.Services.Todos.Update;

public record TodoUpdateRequest(
    int Id,
    string Title,
    string Description);
