public static class TemperatureEndpoints
{
    public static double ToCelsius(double temp, char unit)
    {
        return unit switch
        {
            'C' or 'c' => temp,
            'F' or 'f' => (temp - 32) * (5.0 / 9.0),
            'K' or 'k' => temp - 273.15,
            _ => throw new ArgumentException($"Invalid unit: {unit}. Use C, F, or K.")
        };
    }
    public static void MapTemperatureEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/temp/celsius-to-fahrenheit/{temp}", (double temp) => { return (temp * (9.0 / 5.0)) + 32; });

        app.MapGet("/temp/fahrenheit-to-celsius/{temp}", (double temp) => { return (temp - 32) * 1.8; });

        app.MapGet("/temp/kelvin-to-celsius/{temp}", (double temp) => { return temp - 273.15; });

        app.MapGet("/temp/compare/{temp1}/{unit1}/{temp2}/{unit2}", (int temp1, char unit1, int temp2, char unit2) =>
        { 
            double t1C = ToCelsius(temp1, unit1);
            double t2C = ToCelsius(temp2, unit2);

            if (t1C > t2C)
                return $"Temp1 ({temp1}{unit1}) is hotter than Temp2 ({temp2}{unit2})";
            else if (t1C < t2C)
                return $"Temp2 ({temp2}{unit2}) is hotter than Temp1 ({temp1}{unit1})";
            else
                return $"Both temperatures are equal ({temp1}{unit1} = {temp2}{unit2})";
        });
    }
}