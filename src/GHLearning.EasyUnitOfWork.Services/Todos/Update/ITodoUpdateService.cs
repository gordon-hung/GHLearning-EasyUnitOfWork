namespace GHLearning.EasyUnitOfWork.Services.Todos.Update;

public interface ITodoUpdateService
{
    ValueTask<TodoUpdateResponse> CommandAsync(TodoUpdateRequest request, CancellationToken cancellationToken = default);
}
