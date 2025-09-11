public static class WeatherHistoryEndpoints
{
    public static List<Forecast> forecasts = new List<Forecast>();
    public static void MapWeatherHistoryEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/weather", () =>
        {
            return forecasts;
        });

        app.MapPost("/weather", (Forecast forcast) =>
        {
            forecasts.Add(forcast);
        });

        app.MapDelete("/weather/delete/{date}", (string date) =>
        {
            var toRemove = forecasts.FirstOrDefault(f => f.date == date);

            if (toRemove is null)
            {
                return $"No forecast found for date {date}";
            }

            forecasts.Remove(toRemove);
            return "Forecast deleted";
        });
    }
}