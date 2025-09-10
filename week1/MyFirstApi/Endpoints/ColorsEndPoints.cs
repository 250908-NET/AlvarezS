using Microsoft.VisualBasic;

public static class ColorsEndpoints
{
    public static List<string> colors = new List<string>{"blue", "white", "black", "purple"};
    
    public static void MapColorsEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/colors", () => { return colors; });

        app.MapGet("/colors/random", () =>
        {
            Random r = new Random();
            return colors[r.Next(colors.Count())];
        });

        app.MapGet("/colors/search/{letter}", (char letter) =>
        {
            foreach (var color in colors)
            {
                if (color.Contains(letter))
                {
                    return color;
                }
            }
            return "None";
        });

        app.MapPost("/colors/add/{color}", (string color) => { colors.Add(color); });

    }
}