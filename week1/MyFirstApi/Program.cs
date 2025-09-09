using Microsoft.AspNetCore.Mvc.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// var summaries = new[]
// {
//     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
// };

// app.MapGet("/weatherforecast", () =>
// {
//     var forecast =  Enumerable.Range(1, 5).Select(index =>
//         new WeatherForecast
//         (
//             DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//             Random.Shared.Next(-20, 55),
//             summaries[Random.Shared.Next(summaries.Length)]
//         ))
//         .ToArray();
//     return forecast;
// })
// .WithName("GetWeatherForecast");

//Challenge 1: Calculator
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

//Challenge 2: String Manipulation
app.MapGet("/text/reverse/{text}", (string text) =>
{
    var reversed = "";
    for (int i = text.Length - 1; i >= 0; i--)
    {
        reversed += text[i];
    }

    return reversed;
});

app.MapGet("/text/uppercase/{text}", (string text) =>
{
    return text.ToUpper();
});

app.MapGet("/text/lowercase/{text}", (string text) =>
{
    return text.ToLower();
});

app.MapGet("/text/count/{text}", (string text) =>
{
    var wordCount = text.Split(" ");
    var vowels = new[] { 'a', 'e', 'i', 'o', 'u'}.ToList();
    var vowelCount = 0;
    
    foreach (var letter in text)
    {
        if (vowels.Contains(letter))
        {
            vowelCount += 1;
        }
    }

    return new
    {
        charCount = text.Length,
        wordCount = wordCount.Length,
        vowelCount = vowelCount,
    };
});

app.MapGet("/text/palindrome/{text}", (string text) =>
{
    var l = 0;
    var r = text.Length - 1;

    while (l < r)
    {
        if (text[l] != text[r])
        {
            return false;
        }
        l++;
        r--;
    }
    return true;
});





app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
