using GHLearning.EasyUnitOfWork.Repositories.Todos;
using GHLearning.EasyUnitOfWork.Repositories.Todos.Params;
using Microsoft.Extensions.Logging;

namespace GHLearning.EasyUnitOfWork.Services.Todos.UpdateRollback;
internal class TodoUpdateRollbackService(
	ILogger<TodoUpdateRollbackService> logger,
	IUnitOfWork unitOfWork,
	ITodoRepository repository) : ITodoUpdateRollbackService
{
	public async ValueTask<TodoUpdateRollbackResponse> CommandAsync(TodoUpdateRollbackRequest request, CancellationToken cancellationToken = default)
	{
		_ = await repository.GetByIdAsync(request.Id, cancellationToken)
			.ConfigureAwait(false)
			?? throw new ArgumentNullException(request.Id.ToString());

		await unitOfWork.BeginTransactionAsync(cancellationToken).ConfigureAwait(false);

		try
		{
			await repository.UpdateAsync(new TodoUpdateParam
			(
				Id: request.Id,
				Title: request.Title,
				Description: request.Description
			), cancellationToken).ConfigureAwait(false);

			throw new ArgumentNullException(request.Id.ToString());
		}
		catch (Exception ex)
		{
			logger.LogError(ex, "An error occurred while updating the todo item with ID {Id}.", request.Id);
			await unitOfWork.RollbackAsync(cancellationToken).ConfigureAwait(false);
			throw;
		}
	}
}