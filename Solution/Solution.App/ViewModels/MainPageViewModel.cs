namespace Solution.App.ViewModels;

[ObservableObject]
public partial class MainPageViewModel: Todo
{
    private readonly HttpClient _httpClient;

    [ObservableProperty]
    private ObservableCollection<Todo> todos;

    public IAsyncRelayCommand LoadTodosCommand => new AsyncRelayCommand(OnLoadTodos);
    public IAsyncRelayCommand<Todo> DeleteTodoCommand => new AsyncRelayCommand<Todo>(OnDeleteTodo);

    public MainPageViewModel()
    {
        _httpClient = new HttpClient();
        Todos = new ObservableCollection<Todo>();
       _ = OnLoadTodos();
    }
    private async Task OnLoadTodos()
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

    private async Task OnDeleteTodo(Todo todo)
    {

        await _httpClient.DeleteAsync($"http://localhost:5249/delete/{todo.Id}");
        Todos.Remove(todo);
    }
}
