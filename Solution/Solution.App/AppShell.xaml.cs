namespace Solution.App
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            Routing.RegisterRoute("AddTodoPage", typeof(AddTodoPage));
            Routing.RegisterRoute("EditTodoPage", typeof(EditTodoPage));
            InitializeComponent();
        }
    }
}
