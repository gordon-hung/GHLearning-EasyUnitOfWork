using Dapper.ColumnMapper;
using GHLearning.EasyUnitOfWork.Repositories.Todos;
using GHLearning.EasyUnitOfWork.Repositories.Todos.Tables;
using Microsoft.Extensions.DependencyInjection;

namespace GHLearning.EasyUnitOfWork.Repositories.DependencyInjection;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddEasyUnitOfWorkRepositories(this IServiceCollection services)
		=> services
		.AddColumnTypeMapper()
		.AddTransient<ITodoRepository, TodoRepository>();

	private static IServiceCollection AddColumnTypeMapper(this IServiceCollection services)
	{
		ColumnTypeMapper.RegisterForTypes(typeof(TodoTable), typeof(TodoTable));

		return services;
	}
}