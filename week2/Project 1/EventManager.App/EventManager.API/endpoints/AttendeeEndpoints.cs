using Microsoft.AspNetCore.Mvc;
using EventManager.DTOs;
using EventManager.Services;
public static class AttendeeEndpoints
{

    public static void mapAttendeeEndpoints(this IEndpointRouteBuilder app)
    {
        //Register an attendee
        app.MapPost("/attendees", async ([FromBody] AttendeeCreateDto dto, IAttendeeService service) =>
        {
            var missingFields = new List<string>();

            if (string.IsNullOrWhiteSpace(dto.FirstName))
                missingFields.Add(nameof(dto.FirstName));
            if (string.IsNullOrWhiteSpace(dto.LastName))
                missingFields.Add(nameof(dto.LastName));
            if (string.IsNullOrWhiteSpace(dto.Email))
                missingFields.Add(nameof(dto.Email));
            if (string.IsNullOrWhiteSpace(dto.Phone))
                missingFields.Add(nameof(dto.Phone));

            if (missingFields.Count > 0)
            {
                return Results.BadRequest(new
                {
                    Error = "Missing required fields",
                    MissingFields = missingFields
                });
            }

            var createdAttendee = await service.CreateAsync(dto);
            return Results.Ok( new
            {
                Success = true,
                Data = createdAttendee
            });

        });

        //Update attendee details
        app.MapPut("/attendees/{id}", async (int id, AttendeeUpdateDto dto, IAttendeeService service) =>
        {
            var updatedAttendee = await service.UpdateAsync(id, dto);

            if (updatedAttendee == null)
                return Results.NotFound(new
                {
                    Error = $"Event Id: {id} not found"
                });

            return Results.Ok(new
            {
                Success = true,
                Data = updatedAttendee
            });            
        });

        //Delete attendee by id
        app.MapDelete("/attendees/{id}", async (int id, IAttendeeService service) =>
        {
            var attendee = await service.GetByIdAsync(id);
            
            if (attendee == null)
                return Results.NotFound(new
                {
                    Error = $"Attendee Id: {id} not found"
                });

            await service.DeleteAsync(id);
            return Results.Ok(new
            {
                Success = true,
                Data = attendee
            });
        });
        
        //OPTIONAL
        //Get all attendees (show list of  id + attendee names)
        // app.MapGet("/attendees", async (IAttendeeService service) =>
        // {

        // });

        //Get attendee by id (show all attendee info)
        app.MapGet("/attendees/{id}", async (int id, IAttendeeService service) =>
        {
            var attendee = await service.GetByIdAsync(id);

            if (attendee == null)
                return Results.NotFound( new
                {
                    Error = $"Attendee Id: {id} not found"
                });
            
            return Results.Ok(new
            {
                Success = true,
                Data = attendee
            });            
        });
    }
}