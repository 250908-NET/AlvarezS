public class Forecast
{
    public string weather { get; set; }
    public double temperatureF { get; set; }
    public double temperatureC { get; set; }
    public string city { get; set; }

    public string date { get; set; }

    public Forecast()
    {
        weather = "Clear";
        temperatureF = 70.0;
        temperatureC = 21.1;
        city = "Scotadale";
        date = DateTime.Now.ToShortDateString();
    }

    public Forecast(string weather, double temperatureF, double temperatureC, string city, string date)
    {
        this.weather = weather;
        this.temperatureF = temperatureF;
        this.temperatureC = temperatureC;
        this.city = city;
        this.date = date;

    }

    public override string ToString()
    {
        return $"{city}: {weather}\n{temperatureF}°F\n{temperatureC}°C";
    }
}