namespace TodoListBlazor;

public class TodoItem
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public required string Title { get; init; }
    public bool IsDone { get; set; }
}