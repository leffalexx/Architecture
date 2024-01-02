namespace WeatherApp.Models
{
    public class WeatherForecastHolder
    {
        private List<WeatherForecast> _values;

        public WeatherForecastHolder()
        {
            _values = new List<WeatherForecast>();
        }

        public void Add(DateTime date, int temperatureC)
        {
            WeatherForecast weatherForecast = new WeatherForecast(date, temperatureC);
            _values.Add(weatherForecast);
        }

        public List<WeatherForecast> Get(DateTime dateFrom, DateTime dateTo)
        {
            return _values.FindAll(item => item.Date >= dateFrom && item.Date <= dateTo);
        }

        public bool Update(DateTime date, int temperatureC)
        {
            foreach (var item in _values)
            {
                if (item.Date == date)
                {
                    item.TemperatureC = temperatureC;
                    return true;
                }
            }
            return false;
        }

        public bool Delete(DateTime date)
        {
            for (int i = 0; i < _values.Count; i++)
            {
                if (_values[i].Date == date)
                {
                    _values.RemoveAt(i);
                    return true;
                }
            }

            return false;
        }
    }
}
