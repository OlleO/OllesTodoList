using OllesTodoList.Application.Interfaces;

namespace OllesTodoListApi.Infrastructure;

public class MockTodoListRepository : ITodoListRepository
{
    private readonly List<TodoItem> _todoList = new()
    {
        new() { Id = 1, Title = "First item", Status = "Complete" },
        new() { Id = 2, Title = "Second item", Status = "Incomplete" },
        new() { Id = 3, Title = "Third item", Status = "Complete" },
        new() { Id = 4, Title = "Fourth item", Status = "Incomplete" },
        new() { Id = 5, Title = "Fifth item", Status = "Complete" }
    };


    public async Task<Domain.TodoItem?> GetByIdAsync(long id, CancellationToken ct)
    {
        await Task.CompletedTask;

        var todoItem = _todoList.FirstOrDefault(x => x.Id == id) ?? throw new KeyNotFoundException($"No todo item with id: {id} was found");

        return todoItem.ToDomain();
    }

    public async Task<IEnumerable<Domain.TodoItem>> GetAllAsync(CancellationToken ct)
    {
       await Task.CompletedTask;

       return _todoList.Select(x => x.ToDomain());
    }
}

internal static class TodoItemExtensions
{
    public static Domain.TodoItem ToDomain(this TodoItem from) => new(Id: from.Id, Title: from.Title, Status: from.Status);

}
