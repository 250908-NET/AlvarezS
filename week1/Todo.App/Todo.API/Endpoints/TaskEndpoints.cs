public static class TaskEndpoints
{
    public static TaskService taskService = new TaskService();
    public static void MapTaskEndpoints(this IEndpointRouteBuilder app)
    {
        //Get all tasks with optional filtering
        app.MapGet("/api/tasks", (string? filter) =>
        {
            
        });

        //Get specific task by ID
        app.MapGet("/api/tasks/{id}", (int id) =>
        {

        });

        //Create new task
        app.MapPost("/api/tasks", () =>
        {

        });

        //Update existing task
        app.MapPut("/api/tasks/{id}", (int id) =>
        {

        });

        //Delete task
        app.MapDelete("/api/tasks/{id}", (int id) =>
        {

        });
    }
}