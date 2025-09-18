namespace Solution.App.Views;

public partial class AddTodoPage : ContentPage
{
	public AddTodoPageViewModel ViewModel => ViewModel as AddTodoPageViewModel;
	public AddTodoPage(AddTodoPageViewModel viewModel)
	{
		BindingContext = viewModel;	
		InitializeComponent();
	}
}