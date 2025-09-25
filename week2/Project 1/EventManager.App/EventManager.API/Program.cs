using Microsoft.EntityFrameworkCore;
using EventManager.Data;
using EventManager.Models;
using EventManager.Services;
using EventManager.Repos;


var builder = WebApplication.CreateBuilder(args);

string CS = File.ReadAllText("./connection_string.env");


builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<EventManagerDbContext>(
    options => options.UseSqlServer(CS)
);

builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IAttendeeRepository, AttendeeRepository>();
builder.Services.AddScoped<IEventAttendeeRepository, EventAttendeeRepository>();

builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IAttendeeService, AttendeeService>();
builder.Services.AddScoped<IEventAttendeeService, EventAttendeeService>();

builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.mapAttendeeEndpoints();
app.mapEventEndpoints();
app.mapEventAttendeeEndpoints();

app.Run();