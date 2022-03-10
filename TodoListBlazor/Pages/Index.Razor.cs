using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace TodoListBlazor.Pages
{
    public partial class Index
    {
        ElementReference newTodoInput;
        private string? newTodo;
        private readonly List<TodoItem> todos = new()
        {
            new TodoItem { Id = Guid.NewGuid(), Title = "Do something important! 🙃", IsDone = false },
            new TodoItem { Id = Guid.NewGuid(), Title = "Do not press the button. 🤔", IsDone = false },
            new TodoItem { Id = Guid.NewGuid(), Title = "This task is ok :D", IsDone = true }
        };

        protected override async void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);

            if (firstRender)
                await newTodoInput.FocusAsync();
        }

        public async Task HandleEnter(KeyboardEventArgs e)
        {
            if (e.Code == "Enter" || e.Code == "NumpadEnter")
            {
                await AddTodo();
            }
        }

        public async Task AddTodo()
        {
            if (!string.IsNullOrEmpty(newTodo))
            {
                todos.Add(new TodoItem { Id = Guid.NewGuid(), Title = newTodo });
                newTodo = string.Empty;
                await newTodoInput.FocusAsync();
                await JS.InvokeVoidAsync("Scroll");
            }
        }

        public void DeleteTodo(Guid id)
        {
            todos.RemoveAll(t => t.Id == id);
        }

        public static void CompleteTodo(bool done)
        {
            _ = !done;
        }
    }
}
