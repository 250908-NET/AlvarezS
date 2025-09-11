public static class UnitConverterEndpoints
{
    public static void MapUnitConverterEndpoints(this IEndpointRouteBuilder app)
    {
        //(meters, feet, inches)
        app.MapGet("/convert/length/{value}/{fromUnit}/{toUnit}", (double value, string fromUnit, string toUnit) =>
        {
            double result = 0;

            if (fromUnit == toUnit) return value;

            switch (fromUnit)
            {
                case "meters":
                    if (toUnit == "feet") result = value * 3.281;
                    else result = value * 39.37;
                    break;
                case "feet":
                    if (toUnit == "meters") result = value / 3.281;
                    else result = value * 12;
                    break;
                case "inches":
                    if (toUnit == "meters") result = value / 39.37;
                    else result = value / 12;
                    break;
                default:
                    break;
            }
            return result;
        });

        //(kg, feet, inches)
        app.MapGet("/convert/weight/{value}/{fromUnit}/{toUnit}", (double value, string fromUnit, string toUnit) =>
        { 
            double result = 0;

            if (fromUnit == toUnit) return value;

            switch (fromUnit)
            {
                case "kg":
                    if (toUnit == "lbs") result = value * 2.205;
                    else result = value * 35.274;
                    break;
                case "lbs":
                    if (toUnit == "kg") result = value / 2.205;
                    else result = value * 16;
                    break;
                case "ounces":
                    if (toUnit == "kg") result = value * 35.274;
                    else result = value / 16;
                    break;
                default:
                    break;
            }
            return result;            
        });

        //(liters, gallons, cups)
        app.MapGet("/convert/volume/{value}/{fromUnit}/{toUnit}", (double value, string fromUnit, string toUnit) =>
        { 
            double result = 0;

            if (fromUnit == toUnit) return value;

            switch (fromUnit)
            {
                case "liters":
                    if (toUnit == "gallons") result = value / 3.785;
                    else result = value * 4.167;
                    break;
                case "gallons":
                    if (toUnit == "liters") result = value * 3.785;
                    else result = value * 15.773;
                    break;
                case "cups":
                    if (toUnit == "liters") result = value / 4.167;
                    else result = value / 15.772;
                    break;
                default:
                    break;
            }
            return result;              
        });

        //(length, weight, volume)
        app.MapGet("/convert/list-units/{type}", (string type) =>
        {
            var units = new Dictionary<string, string[]>
            {
                {"length", new[] { "meters", "feet", "inches" }},
                {"weight", new[] { "kg", "lbs", "ounces" }},
                {"volume", new[] { "liters", "gallons", "cups" }}
            };
            return units[type];
        });
    }
}