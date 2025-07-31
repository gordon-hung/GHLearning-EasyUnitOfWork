namespace GHLearning.EasyUnitOfWork.Repositories.Todos.Params;

public record TodoUpdateParam(
    int Id,
    string Title,
    string Description);
