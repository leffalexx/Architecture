namespace WeatherApp.Models
{
    public class WeatherForecast
    {
        public int TemperatureC { get; set; }

        public DateTime Date { get; set; }

        public WeatherForecast(DateTime date, int temperatureC)
        {
            Date = date;
            TemperatureC = temperatureC;
        }
        public int TemperatureF
        {
            get { return 32 + (int)(TemperatureC / 0.5556); }
        }
    }
}
