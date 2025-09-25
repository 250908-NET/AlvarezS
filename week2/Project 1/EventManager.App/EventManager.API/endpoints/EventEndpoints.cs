using Microsoft.AspNetCore.Mvc;
using EventManager.DTOs;
using EventManager.Services;
public static class EventEndpoints
{
    public static void mapEventEndpoints(this IEndpointRouteBuilder app)
    {
        //Register an event
        app.MapPost("/events", async ([FromBody] EventCreateDto dto, IEventService service) =>
        {
            var missingFields = new List<string>();

            if (string.IsNullOrWhiteSpace(dto.Title))
                missingFields.Add(nameof(dto.Title));
            if (string.IsNullOrWhiteSpace(dto.Description))
                missingFields.Add(nameof(dto.Description));
            if (string.IsNullOrWhiteSpace(dto.Location))
                missingFields.Add(nameof(dto.Location));
            if (string.IsNullOrWhiteSpace(dto.StartDate))
                missingFields.Add(nameof(dto.StartDate));
            if (string.IsNullOrWhiteSpace(dto.StartTime))
                missingFields.Add(nameof(dto.StartTime));
            if (string.IsNullOrWhiteSpace(dto.EndDate))
                missingFields.Add(nameof(dto.EndDate));
            if (string.IsNullOrWhiteSpace(dto.EndTime))
                missingFields.Add(nameof(dto.EndTime));

            if (missingFields.Count > 0)
            {
                return Results.BadRequest(new
                {
                    Error = "Missing required fields",
                    MissingFields = missingFields
                });
            }

            // Try parsing StartDate + StartTime
            if (!DateTime.TryParse($"{dto.StartDate} {dto.StartTime}", out var startDateTime))
                return Results.BadRequest(new { Error = "Invalid StartDate or StartTime format. Expected YYYY-MM-DD and HH:MM" });

            // Try parsing EndDate + EndTime
            if (!DateTime.TryParse($"{dto.EndDate} {dto.EndTime}", out var endDateTime))
                return Results.BadRequest(new { Error = "Invalid EndDate or EndTime format. Expected YYYY-MM-DD and HH:MM" });

            var createdEvent = await service.CreateAsync(dto);
            return Results.Ok( new
            {
                Success = true,
                Data = createdEvent
            });
        });

        //Update event details
        app.MapPut("/events/{id}", async (int id, EventUpdateDto dto, IEventService service)=>
        {
            var updatedEvent = await service.UpdateAsync(id, dto);

            if (updatedEvent == null)
                return Results.NotFound(new
                {
                    Error = $"Event Id: {id} not found"
                });

            return Results.Ok(new
            {
                Success = true,
                Data = updatedEvent
            });
        });
        
        //Delete event by id
        app.MapDelete("/events/{id}", async (int id, IEventService service) =>
        {
            var ev = await service.GetByIdAsync(id);
            
            if (ev == null)
                return Results.NotFound(new
                {
                    Error = $"Event Id: {id} not found"
                });

            await service.DeleteAsync(id);
            return Results.Ok(new
            {
                Success = true,
                Data = ev
            });
        });

        //Get all events (show list of  id + event names + descriptions)
        app.MapGet("/events", async (IEventService service) =>
        {
            var events = await service.GetAllAsync();
            
            var result = events.Select(e => new
            {
                e.Id,
                e.Title,
                e.Description
            });

            return Results.Ok(new
            {
                Success = true,
                Data = result
            });
        });

        //Get event by id (show all event info)
        app.MapGet("/events/{id}", async (int id, IEventService service) =>
        {
            var ev = await service.GetByIdAsync(id);

            if (ev == null)
                return Results.NotFound( new
                {
                    Error = $"Event Id: {id} not found"
                });
            
            return Results.Ok(new
            {
                Success = true,
                Data = ev
            });
        });
    }
}