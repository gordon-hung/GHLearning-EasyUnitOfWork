using System.Runtime.CompilerServices;
using GHLearning.EasyUnitOfWork.Repositories.Todos;

namespace GHLearning.EasyUnitOfWork.Services.Todos.Query;

internal class TodoQueryService(
    ITodoRepository repository) : ITodoQueryService
{
    public async IAsyncEnumerable<TodoQueryResponse> QueryAsync(TodoQueryRequest request,[EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var todos = await repository.GetAllAsync(cancellationToken)
             .ToArrayAsync(cancellationToken)
             .ConfigureAwait(false);

        foreach (var todo in todos)
        {
            yield return new TodoQueryResponse(
                Id: todo.Id,
                Title: todo.Title,
                Description: todo.Description,
                CreatedAt: todo.CreatedAt,
                UpdatedAt: todo.UpdatedAt);
        }
    }
}
