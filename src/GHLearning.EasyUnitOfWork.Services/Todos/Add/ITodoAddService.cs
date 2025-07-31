namespace GHLearning.EasyUnitOfWork.Services.Todos.Add;

public interface ITodoAddService
{
    ValueTask CommandAsync(TodoAddRequest request, CancellationToken cancellationToken = default);
}
