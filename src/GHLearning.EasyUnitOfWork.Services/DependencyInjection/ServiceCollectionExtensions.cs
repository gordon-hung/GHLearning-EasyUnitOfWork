using GHLearning.EasyUnitOfWork.Services.Todos.Add;
using GHLearning.EasyUnitOfWork.Services.Todos.GetById;
using GHLearning.EasyUnitOfWork.Services.Todos.Query;
using GHLearning.EasyUnitOfWork.Services.Todos.Update;
using GHLearning.EasyUnitOfWork.Services.Todos.UpdateRollback;
using Microsoft.Extensions.DependencyInjection;

namespace GHLearning.EasyUnitOfWork.Services.DependencyInjection;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddEasyUnitOfWorkServices(this IServiceCollection services)
	=> services.AddTransient<ITodoAddService, TodoAddService>()
		.AddTransient<ITodoGetByIdService, TodoGetByIdService>()
		.AddTransient<ITodoQueryService, TodoQueryService>()
		.AddTransient<ITodoUpdateService, TodoUpdateService>()
		.AddTransient<ITodoUpdateRollbackService, TodoUpdateRollbackService>();
}
