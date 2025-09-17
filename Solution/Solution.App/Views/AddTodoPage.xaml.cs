namespace Solution.App.Views;

public partial class AddTodoPage : ContentPage
{
	public AddTodoPageViewModel AddTodoPageViewModel => BindingContext as AddTodoPageViewModel;
	public AddTodoPage(AddTodoPageViewModel viewModel)
	{
		BindingContext = viewModel;	
		InitializeComponent();
	}
}