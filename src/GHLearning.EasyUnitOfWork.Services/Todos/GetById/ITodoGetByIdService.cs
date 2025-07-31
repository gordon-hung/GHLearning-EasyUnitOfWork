namespace GHLearning.EasyUnitOfWork.Services.Todos.GetById;

public interface ITodoGetByIdService
{
    ValueTask<TodoGetByIdResponse?> GetAsync(TodoGetByIdRequest request, CancellationToken cancellationToken = default);
}
