using Microsoft.AspNetCore.Mvc;

public static class TaskEndpoints
{
    public static TaskService taskService = new TaskService();
    public static void MapTaskEndpoints(this IEndpointRouteBuilder app)
    {
        //Get all tasks with optional filtering
        app.MapGet("/api/tasks", (string? filter, [FromQuery] string? dueBefore, [FromQuery] Priority? priority) =>
        {
            //TODO: Get filter attributes from body
            var tasks = taskService.getAllTasksByFilters(filter, dueBefore, priority);
            if (tasks != null)
            {
                return Results.Ok(new
                {
                    success = true,
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
        });

        //Get specific task by ID
        app.MapGet("/api/tasks/{id}", (int id) =>
        {
            var task = taskService.getTaskById(id);

            if (task != null)
            {
                return Results.Ok(new
                {
                    success = true,
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
        });

        //Create new task
        app.MapPost("/api/tasks", (TaskItem body) =>
        {           
            if (string.IsNullOrWhiteSpace(body.title))
            {
                return Results.BadRequest(new
                {
                    success = false,
                    message = "Title is required"
                });
            }

            var task = taskService.addTask(
                body.title, 
                body.priority, 
                body.description, 
                body.dueDate?.ToString()
            );

            return Results.Ok(new
            {
                success = true,
                message = "Task created",
                data = task
            });
        });

        //Update existing task
        app.MapPut("/api/tasks/{id}", (int id, TaskItem body) =>
        {
            //get data from body
            //TODO: return OK or BR and error message
            var updated = taskService.updateTaskById(
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
                message = "Task updated", 
                data = updated 
            });
        });

        //Delete task
        app.MapDelete("/api/tasks/{id}", (int id) =>
        {
            var task = taskService.removeTaskById(id);
            if (task != null)
            {
                return Results.Ok(new
                {
                    success = true,
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
        });
    }
}