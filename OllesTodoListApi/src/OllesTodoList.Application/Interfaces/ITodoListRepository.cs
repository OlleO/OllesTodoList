using OllesTodoListApi.Domain;

namespace OllesTodoList.Application.Interfaces;

public interface ITodoListRepository
{
    Task<TodoItem?> GetByIdAsync(long id, CancellationToken ct);
    Task<IEnumerable<TodoItem>> GetAllAsync(CancellationToken ct);
}
