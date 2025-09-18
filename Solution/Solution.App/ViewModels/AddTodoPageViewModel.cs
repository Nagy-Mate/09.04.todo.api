using Microsoft.Maui.Controls.Shapes;

namespace Solution.App.ViewModels;

[ObservableObject]
public partial class AddTodoPageViewModel
{
    private readonly HttpClient _httpClient;

    [ObservableProperty]
    private string titleE;

    [ObservableProperty]
    private DateTime minDate;

    [ObservableProperty]
    private DateTime selectedDate;

    [ObservableProperty]
    private string descriptionE;

    public IAsyncRelayCommand AddTodoCommand => new AsyncRelayCommand(OnAddTodo);
    public AddTodoPageViewModel()
    {
        _httpClient = new HttpClient(); 
        MinDate = DateTime.Now;
        SelectedDate = DateTime.Now;
    }
    private async Task OnAddTodo()
    {
        if (!string.IsNullOrWhiteSpace(TitleE))
        {
            var newTodo = new Todo
            {
                Title = TitleE,
                Description = DescriptionE,
                Created = DateTime.Now,
                DeadLine = SelectedDate,
                IsReady = false,
            };
            try
            {
                var res = await _httpClient.PostAsJsonAsync("http://localhost:5249/create/", newTodo);
               
                TitleE = string.Empty;
                DescriptionE = string.Empty;
                SelectedDate = DateTime.Now;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: { ex.Message}");
            }
        }
        
    }
}
