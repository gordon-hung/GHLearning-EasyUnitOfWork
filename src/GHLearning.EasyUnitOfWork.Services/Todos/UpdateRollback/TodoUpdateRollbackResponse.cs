namespace GHLearning.EasyUnitOfWork.Services.Todos.UpdateRollback;
public record TodoUpdateRollbackResponse(
	int Id,
	string Title,
	string Description,
	DateTimeOffset CreatedAt,
	DateTimeOffset UpdatedAt);