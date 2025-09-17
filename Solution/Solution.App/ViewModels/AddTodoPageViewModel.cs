namespace Solution.App.ViewModels;

[ObservableObject]
public partial class AddTodoPageViewModel: Todo
{
    private readonly HttpClient _httpClient;

    [ObservableProperty]
    private string titleE;

    [ObservableProperty]
    private DateTime? minDate;

    [ObservableProperty]
    private DateTime selectedDate;

    [ObservableProperty]
    private string descriptionE;

    public IAsyncRelayCommand AddTodoCommand => new AsyncRelayCommand(OnAddTodo);
    public AddTodoPageViewModel()
    {
        _httpClient = new HttpClient(); 
        minDate = DateTime.Now;
    }
    private async Task OnAddTodo()
    {
        var newTodo = new Todo
        {
            Title = titleE,
            Description = descriptionE,
            Created = DateTime.Now,
            DeadLine = selectedDate,
            IsReady = false,
        };

        try
        {
            var res = await _httpClient.PostAsJsonAsync("http://localhost:5249/create/", newTodo);
            titleE = string.Empty;
            descriptionE = string.Empty;
            selectedDate = DateTime.Now;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: { ex.Message}");
        }
    }
}
