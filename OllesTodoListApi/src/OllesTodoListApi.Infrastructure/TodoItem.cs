namespace OllesTodoListApi.Infrastructure;

public class TodoItem
{
    public long Id { get; set; }
    public required string Title { get; set; }
    public required string Status { get; set; }
}
