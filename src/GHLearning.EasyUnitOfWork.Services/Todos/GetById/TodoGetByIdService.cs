using GHLearning.EasyUnitOfWork.Repositories.Todos;

namespace GHLearning.EasyUnitOfWork.Services.Todos.GetById;

internal class TodoGetByIdService(
    ITodoRepository repository) : ITodoGetByIdService
{
    public async ValueTask<TodoGetByIdResponse?> GetAsync(TodoGetByIdRequest request, CancellationToken cancellationToken = default)
    {
        var todo = await repository.GetByIdAsync(
            id: request.Id,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        return todo is null
            ? null
            : new TodoGetByIdResponse(todo.Id, todo.Title, todo.Description, todo.CreatedAt, todo.UpdatedAt);
    }
}
