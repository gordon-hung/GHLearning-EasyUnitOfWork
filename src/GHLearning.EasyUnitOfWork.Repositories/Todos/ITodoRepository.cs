using GHLearning.EasyUnitOfWork.Repositories.Todos.Dtos;
using GHLearning.EasyUnitOfWork.Repositories.Todos.Params;

namespace GHLearning.EasyUnitOfWork.Repositories.Todos;

public interface ITodoRepository
{
    ValueTask AddAsync(TodoAddParam param, CancellationToken cancellationToken = default);

    ValueTask UpdateAsync(TodoUpdateParam param, CancellationToken cancellationToken = default);
    IAsyncEnumerable<TodoDto> GetAllAsync(CancellationToken cancellationToken = default);
    ValueTask<TodoDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
}
