namespace GHLearning.EasyUnitOfWork.Services.Todos.UpdateRollback;
public interface ITodoUpdateRollbackService
{
	ValueTask<TodoUpdateRollbackResponse> CommandAsync(TodoUpdateRollbackRequest request, CancellationToken cancellationToken = default);
}
