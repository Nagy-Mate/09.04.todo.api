namespace Solution.App
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            //Views
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<AddTodoPage>();
            builder.Services.AddTransient<EditTodoPage>();

            //ViewModels
            builder.Services.AddTransient<MainPageViewModel>();
            builder.Services.AddTransient<AddTodoPageViewModel>();
            builder.Services.AddTransient<EditTodoPageViewModel>();



#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
