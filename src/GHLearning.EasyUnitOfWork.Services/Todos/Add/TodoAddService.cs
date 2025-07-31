using Microsoft.Extensions.Logging;
using GHLearning.EasyUnitOfWork.Repositories.Todos;
using GHLearning.EasyUnitOfWork.Repositories.Todos.Params;

namespace GHLearning.EasyUnitOfWork.Services.Todos.Add;

internal class TodoAddService(
    ILogger<TodoAddService> logger,
    IUnitOfWork unitOfWork,
    ITodoRepository todoRepository) : ITodoAddService
{
    public async ValueTask CommandAsync(TodoAddRequest request, CancellationToken cancellationToken = default)
    {
        await unitOfWork.BeginTransactionAsync(cancellationToken).ConfigureAwait(false);

        try
        {
            await todoRepository.AddAsync(
                new TodoAddParam(
                    request.Title,
                    request.Description),
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);

            await unitOfWork.CommitAsync(cancellationToken).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while adding a todo item.");
            await unitOfWork.RollbackAsync(cancellationToken).ConfigureAwait(false);
            throw;
        }
    }
}
