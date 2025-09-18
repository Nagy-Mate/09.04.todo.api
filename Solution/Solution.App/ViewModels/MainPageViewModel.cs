namespace Solution.App.ViewModels;

[ObservableObject]
public partial class MainPageViewModel: Todo
{
    private readonly HttpClient _httpClient;

    [ObservableProperty]
    private ObservableCollection<Todo> todos;

    public IAsyncRelayCommand LoadTodosCommand => new AsyncRelayCommand(OnLoadTodos);
    public IAsyncRelayCommand ReadyTodoCommand => new AsyncRelayCommand<Todo>(OnReadyTodo);
    public IAsyncRelayCommand<Todo> DeleteTodoCommand => new AsyncRelayCommand<Todo>(OnDeleteTodo);

    public MainPageViewModel()
    {
        _httpClient = new HttpClient();
        Todos = new ObservableCollection<Todo>();
       _ = OnLoadTodos();
    }
    private async Task OnLoadTodos()
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<List<Todo>>("http://localhost:5249/list");

            if (response != null)
            {
                Todos.Clear();
                foreach (var todo in response)
                {
                    Todos.Add(todo);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private async Task OnDeleteTodo(Todo todo)
    {
        try
        {
            await _httpClient.DeleteAsync($"http://localhost:5249/delete/{todo.Id}");
            Todos.Remove(todo);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private async Task OnReadyTodo(Todo todo)
    {
        try
        {
            await _httpClient.PutAsJsonAsync($"http://localhost:5249/ready/{todo.Id}", todo);

            await OnLoadTodos();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
