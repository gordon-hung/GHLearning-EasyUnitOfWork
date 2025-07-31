using GHLearning.EasyUnitOfWork.Repositories.Todos;
using GHLearning.EasyUnitOfWork.Repositories.Todos.Params;
using Microsoft.Extensions.Logging;

namespace GHLearning.EasyUnitOfWork.Services.Todos.Update;

internal class TodoUpdateService(
	ILogger<TodoUpdateService> logger,
	IUnitOfWork unitOfWork,
	ITodoRepository repository) : ITodoUpdateService
{
	public async ValueTask<TodoUpdateResponse> CommandAsync(TodoUpdateRequest request, CancellationToken cancellationToken = default)
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

			var doto = await repository.GetByIdAsync(request.Id, cancellationToken)
				.ConfigureAwait(false)
				?? throw new ArgumentNullException(request.Id.ToString());

			await unitOfWork.CommitAsync(cancellationToken).ConfigureAwait(false);

			return new TodoUpdateResponse
			(
				Id: doto.Id,
				Title: doto.Title,
				Description: doto.Description,
				CreatedAt: doto.CreatedAt,
				UpdatedAt: doto.UpdatedAt
			);
		}
		catch (Exception ex)
		{
			logger.LogError(ex, "An error occurred while updating the todo item with ID {Id}.", request.Id);
			await unitOfWork.RollbackAsync(cancellationToken).ConfigureAwait(false);
			throw;
		}
	}
}
