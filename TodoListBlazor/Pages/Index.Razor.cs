using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace TodoListBlazor.Pages;

public partial class Index
{
    private ElementReference _newTodoInput;
    private string? _newTodo;
    private bool _isDarkTheme;

    private readonly List<TodoItem> _todos =
    [
        new() { Id = Guid.NewGuid(), Title = "Do something important! 🙃", IsDone = false },
        new() { Id = Guid.NewGuid(), Title = "Do not press the button. 🤔", IsDone = false },
        new() { Id = Guid.NewGuid(), Title = "This task is ok :D", IsDone = true }
    ];

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            _isDarkTheme = await Js.InvokeAsync<bool>("isDarkTheme");
            StateHasChanged();

            await _newTodoInput.FocusAsync();
        }
    }

    private async Task HandleEnter(KeyboardEventArgs e)
    {
        if (e.Code is "Enter" or "NumpadEnter")
        {
            await AddTodo();
        }
    }

    private async Task AddTodo()
    {
        if (!string.IsNullOrWhiteSpace(_newTodo))
        {
            _todos.Add(new TodoItem { Id = Guid.NewGuid(), Title = _newTodo.Trim() });
            _newTodo = string.Empty;
            StateHasChanged();

            await _newTodoInput.FocusAsync();
            await Js.InvokeVoidAsync("Scroll");
        }
    }

    private void DeleteTodo(Guid id)
    {
        _todos.RemoveAll(t => t.Id == id);
    }

    private async Task ToggleTheme()
    {
        _isDarkTheme = !_isDarkTheme;
        await Js.InvokeVoidAsync("toggleTheme", _isDarkTheme);
    }
}