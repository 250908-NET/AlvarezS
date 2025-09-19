using Microsoft.AspNetCore.Mvc;

public static class TaskEndpoints
{
    public static TaskService taskService = new TaskService();
    public static void MapTaskEndpoints(this IEndpointRouteBuilder app)
    {
        //Get all tasks with optional filtering
        app.MapGet("/api/tasks", (HttpContext http, string? filter, [FromQuery] string? dueBefore, [FromQuery] Priority? priority) =>
        {
            var username = http.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            List<TaskItem>? tasks = null; 
            if(!string.IsNullOrEmpty(username))
                 tasks = taskService.getAllTasksByFilters(username, filter, dueBefore, priority);
            if (tasks != null)
            {
                return Results.Ok(new
                {
                    success = true,
                    user = username,
                    filter = filter,
                    message = "Operation completed successfully",
                    data = tasks,
                });
            }

            return Results.BadRequest(new
            {
                success = false,
                filter = filter,
                message = "Operation failed",
                error = $"Unsupported filter. Try [isCompleted, priority, dueBefore]",
            });
        }).RequireAuthorization();

        //Get specific task by ID
        app.MapGet("/api/tasks/{id}", (HttpContext http, int id) =>
        {
            var username = http.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            TaskItem? task = null;
            
            if(!string.IsNullOrEmpty(username))
                task = taskService.getTaskById(username, id);

            if (task != null)
            {
                return Results.Ok(new
                {
                    success = true,
                    user = username,
                    message = "Operation completed successfully",
                    data = task,
                });
            }

            return Results.BadRequest(new
            {
                success = false,
                message = "Operation failed",
                error = $"Id not found",
            });
        }).RequireAuthorization();

        //Create new task
        app.MapPost("/api/tasks", (HttpContext http, TaskItem body) =>
        {           
            var username = http.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            // foreach (var claim in http.User.Claims)
            //     Console.WriteLine($"{claim.Type} = {claim.Value}");
            


            if (string.IsNullOrWhiteSpace(body.title))
            {
                return Results.BadRequest(new
                {
                    success = false,
                    message = "Title is required"
                });
            }


            TaskItem? task = null;
            
            if(!string.IsNullOrEmpty(username))
                task = taskService.addTask(
                username, 
                body.title, 
                body.priority, 
                body.description, 
                body.dueDate?.ToString()
            );

            return Results.Ok(new
            {
                success = true,
                user = username,
                message = "Task created",
                data = task
            });
        }).RequireAuthorization();

        //Update existing task
        app.MapPut("/api/tasks/{id}", (HttpContext http, int id, TaskItem body) =>
        {
            var username = http.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            TaskItem? updated = null;
            
            if(!string.IsNullOrEmpty(username))
                updated = taskService.updateTaskById
            (
                username,
                id,
                title: body.title,
                desc: body.description,
                isCompleted: body.isCompleted,
                priority: body.priority,
                dueDate: body.dueDate?.ToString()
            );

            if (updated is null)
            {
                return Results.BadRequest(new
                {
                    success = false,
                    message = "Task not found or update failed"
                });
            }

            return Results.Ok(new 
            {
                success = true, 
                user = username,
                message = "Task updated", 
                data = updated 
            });
        }).RequireAuthorization();

        //Delete task
        app.MapDelete("/api/tasks/{id}", (HttpContext http, int id) =>
        {
            var username = http.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            TaskItem? task = null;
            
            if(!string.IsNullOrEmpty(username))
                task = taskService.removeTaskById(username, id);
            if (task != null)
            {
                return Results.Ok(new
                {
                    success = true,
                    user = username,
                    message = "Operation completed successfully",
                    data = task,
                });
            }

            return Results.BadRequest(new
            {
                success = false,
                message = "Operation failed",
                error = $"Id not found",
            });
        }).RequireAuthorization();
    }
}