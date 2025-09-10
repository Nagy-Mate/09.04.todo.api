using Solution.Common;
using System.Net.Http.Json;

namespace Solution.App
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
        private async void OnWBtnClicked(object? sender, EventArgs e)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetFromJsonAsync<List<WeatherForecast>>("http://localhost:5249/weatherforecast");

            WInfo.Text = response.First().Summary;
        }
    }
}
