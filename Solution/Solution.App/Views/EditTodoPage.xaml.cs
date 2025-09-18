namespace Solution.App.Views;

public partial class EditTodoPage : ContentPage
{
	public EditTodoPageViewModel viewModel => viewModel as EditTodoPageViewModel;
	public EditTodoPage(EditTodoPageViewModel viewModel)
	{
		BindingContext = viewModel;	
		InitializeComponent();
	}
}