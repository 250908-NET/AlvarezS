using Microsoft.EntityFrameworkCore;
using EventManager.Data;
using EventManager.Models;

var builder = WebApplication.CreateBuilder(args);

string CS = File.ReadAllText("./connection_string.env");


builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<EventManagerDbContext>(
    options => options.UseSqlServer(CS)
);


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.mapEventEndpoints();

app.Run();