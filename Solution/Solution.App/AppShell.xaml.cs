namespace Solution.App
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            Routing.RegisterRoute("AddTodoPage", typeof(AddTodoPage));
            InitializeComponent();
        }
    }
}
