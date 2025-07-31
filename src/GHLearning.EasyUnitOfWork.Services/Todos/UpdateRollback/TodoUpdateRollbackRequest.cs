namespace GHLearning.EasyUnitOfWork.Services.Todos.UpdateRollback;
public record TodoUpdateRollbackRequest(
	int Id,
	string Title,
	string Description);
