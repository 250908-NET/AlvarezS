public static class CalculatorEndpoints
{
    public static void MapCalculatorEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/calculator/add/{a}/{b}", (int a, int b) =>
        {
            return new
            {
                operation = "add",
                result = a + b
            };
        });

        app.MapGet("/calculator/subtract/{a}/{b}", (int a, int b) =>
        {
            return new
            {
                operation = "subtract",
                result = a - b
            };
        });

        app.MapGet("/calculator/multiply/{a}/{b}", (int a, int b) =>
        {
            return new
            {
                operation = "multiply",
                result = a * b
            };
        });

        app.MapGet("/calculator/divide/{a:int}/{b:int}", (int a, int b) =>
        {
            return b == 0
                ? Results.BadRequest(new { Message = "Division by 0 is not allowed." })
                : Results.Ok(new { operation = "divide", result = (double)a / b });
        });
    }
}