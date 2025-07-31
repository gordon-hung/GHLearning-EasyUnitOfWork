namespace GHLearning.EasyUnitOfWork.Services.Todos.Query;

public interface ITodoQueryService
{
    IAsyncEnumerable<TodoQueryResponse> QueryAsync(TodoQueryRequest request, CancellationToken cancellationToken = default);
}
