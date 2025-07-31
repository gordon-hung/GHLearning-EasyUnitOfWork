using Dapper;
using System.Runtime.CompilerServices;
using GHLearning.EasyUnitOfWork.Repositories.Todos.Dtos;
using GHLearning.EasyUnitOfWork.Repositories.Todos.Params;
using GHLearning.EasyUnitOfWork.Repositories.Todos.Tables;

namespace GHLearning.EasyUnitOfWork.Repositories.Todos;

internal class TodoRepository(
	IUnitOfWork unitOfWork,
	TimeProvider timeProvider) : ITodoRepository
{
	public async ValueTask AddAsync(TodoAddParam param, CancellationToken cancellationToken = default)
		=> _ = await unitOfWork.Connection.ExecuteAsync(
			"""
            INSERT INTO sample.todo
                        (title,
                            description,
                            created_at,
                            updated_at)
            VALUES     (@title,
                        @description,
                        @currentTime,
                        @currentTime); 
            """,
			new
			{
				title = param.Title,
				description = param.Description,
				currenttime = timeProvider.GetUtcNow().UtcDateTime
			}, unitOfWork.Transaction)
		.ConfigureAwait(false);

	public async IAsyncEnumerable<TodoDto> GetAllAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
	{
		var tables = await unitOfWork.Connection.QueryAsync<TodoTable>(
			"""
            SELECT id,
                   title,
                   description,
                   created_at,
                   updated_at
            FROM   sample.todo; 
            """,
			transaction: unitOfWork.Transaction).ConfigureAwait(false);

		foreach (var table in tables)
		{
			yield return new TodoDto
			(
				Id: table.Id,
				Title: table.Title,
				Description: table.Description,
				CreatedAt: new DateTimeOffset(table.CreatedAt, TimeSpan.Zero),
				UpdatedAt: new DateTimeOffset(table.UpdatedAt, TimeSpan.Zero)
			);
		}
	}

	public async ValueTask<TodoDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
	{
		var table = await unitOfWork.Connection.QueryFirstOrDefaultAsync<TodoTable>(
			"""
            SELECT id,
                   title,
                   description,
                   created_at,
                   updated_at
            FROM   sample.todo
            WHERE  id = @id; 
            """,
			new
			{
				id
			},
			transaction: unitOfWork.Transaction).ConfigureAwait(false);

		return table is null
			? null
			: new TodoDto
			(
				Id: table.Id,
				Title: table.Title,
				Description: table.Description,
				CreatedAt: new DateTimeOffset(table.CreatedAt, TimeSpan.Zero),
				UpdatedAt: new DateTimeOffset(table.UpdatedAt, TimeSpan.Zero)
			);
	}

	public async ValueTask UpdateAsync(TodoUpdateParam param, CancellationToken cancellationToken = default)
		=> _ = await unitOfWork.Connection.ExecuteAsync(
			"""
            UPDATE sample.todo
            SET    title = @title,
                   description = @description,
                   updated_at = @currenttime
            WHERE  id = @id; 
            """,
			new
			{
				id = param.Id,
				title = param.Title,
				description = param.Description,
				currenttime = timeProvider.GetUtcNow().UtcDateTime
			}, unitOfWork.Transaction)
		.ConfigureAwait(false);
}
