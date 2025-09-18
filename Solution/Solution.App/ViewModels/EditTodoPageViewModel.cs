namespace Solution.App.ViewModels;

[ObservableObject]
public partial class EditTodoPageViewModel: Todo
{
    private readonly HttpClient _httpClient;

    [ObservableProperty]
    private ObservableCollection<Todo> todos;

    [ObservableProperty]
    private Todo selectedTodoForEdit;

    [ObservableProperty]
    private string newTitle;

    [ObservableProperty]
    private string newDescription;

    [ObservableProperty]
    private DateTime minDate;

    [ObservableProperty]
    private DateTime selectedNewDate;

    public IAsyncRelayCommand EditTodoCommand => new AsyncRelayCommand(OnEditTodo);
    public EditTodoPageViewModel()
    {
        _httpClient = new HttpClient();
        Todos = new ObservableCollection<Todo>();
        MinDate = DateTime.Now;

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
        }catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

    }

    private async Task OnEditTodo()
    {   
        if (SelectedTodoForEdit != null)
        {
            var todo = Todos.FirstOrDefault(t => t.Id == SelectedTodoForEdit.Id);

            var editedTodo = new Todo
            {
                Id = SelectedTodoForEdit.Id,
                Title = string.IsNullOrWhiteSpace(NewTitle) ? todo.Title : NewTitle,
                Description = string.IsNullOrWhiteSpace(NewDescription) ? todo.Description : NewDescription,
                DeadLine = SelectedNewDate < DateTime.Now ? todo.DeadLine : SelectedNewDate
            };
            await _httpClient.PutAsJsonAsync("http://localhost:5249/update/", editedTodo);
            NewTitle = string.Empty;
            NewDescription = string.Empty;
            SelectedNewDate = DateTime.Now;

            await OnLoadTodos();  
        }
    }
}
