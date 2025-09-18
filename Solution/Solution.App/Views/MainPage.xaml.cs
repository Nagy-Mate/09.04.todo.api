namespace Solution.App.Views;

public partial class MainPage : ContentPage
{
    public MainPageViewModel MainPageViewModel => BindingContext as MainPageViewModel;

    public MainPage(MainPageViewModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();
    }
}
