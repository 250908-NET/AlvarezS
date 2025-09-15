public static class TaskEndpoints
{
    public static void MapTaskEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/tasks", () =>
        {
            
        });

        app.MapGet("/api/tasks/{id}", (int id) => { 

        });

        app.MapPost("/api/tasks", () => { 

        });

        app.MapPut("/api/tasks/{id}", (int id) => { 

        });

        app.MapDelete("/api/tasks/{id}", (int id) => { 

        });

    }
}