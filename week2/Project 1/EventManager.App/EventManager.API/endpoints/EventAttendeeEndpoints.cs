using Microsoft.AspNetCore.Mvc;
using EventManager.DTOs;
using EventManager.Models;
using EventManager.Services;
public static class EventAttendeeEndpoints
{
    public static void mapEventAttendeeEndpoints(this IEndpointRouteBuilder app)
    {
        //Register an Attendee to an event
        app.MapPost("/events/{eventId}/Attendee/{attendeeId}", async (int eventId, int attendeeId, IEventAttendeeService service, IAttendeeService aService, IEventService eService) =>
        {

            var existingAttendee = await aService.GetByIdAsync(attendeeId);
            if (existingAttendee == null)
            {
                return Results.NotFound(new
                {
                    Success = false,
                    Error = $"Attendee {attendeeId} does not exist."
                });
            }

            var existingEvent = await eService.GetByIdAsync(eventId);
            if (existingEvent == null)
            {
                return Results.NotFound(new
                {
                    Success = false,
                    Error = $"Event {eventId} does not exist."
                });
            }

            // Check if this attendee is already registered for the event
            var existing = await service.GetByIdAsync(eventId, attendeeId);
            if (existing != null)
            {
                return Results.BadRequest(new
                {
                    Success = false,
                    Error = $"Attendee {attendeeId} is already registered for Event {eventId}."
                });
            }

            // Register attendee
            await service.CreateAsync(eventId, attendeeId);

            return Results.Ok(new
            {
                Success = true,
                Message = $"Attendee {attendeeId} successfully registered for Event {eventId}."
            });            
        });
        
        //Get all Attendees at an Event 
        app.MapGet("/event/{eventId}/attendees", async (int eventId, IEventAttendeeService service) =>
        {
            // Check if the event exists
            if (!await service.EventExistsAsync(eventId))
            {
                return Results.BadRequest(new
                {
                    Success = false,
                    Message = $"Event {eventId} does not exist."
                });
    }
            var attendees = await service.GetAttendeesByEventIdAsync(eventId);

            return Results.Ok(new
            {
                Success = true,
                Data = attendees
            });
        });

        //Get all Events Attendee is signed up for
        app.MapGet("/attendee/{attendeeId}/events", async (int attendeeId, IEventAttendeeService service) =>
        {
            // Check if the Attendee exists
            if (!await service.AttendeeExistsAsync(attendeeId))
            {
                return Results.NotFound(new
                {
                    Success = false,
                    Message = $"Attendee {attendeeId} does not exist."
                });
            }
            var events = await service.GetEventsByAttendeeIdAsync(attendeeId);

            return Results.Ok(new
            {
                Success = true,
                Data = events
            });
        });
        
        //Delete Attendee from Event
        app.MapDelete("/events/{eventId}/Attendees/{attendeeId}", async (int eventId, int attendeeId, IEventAttendeeService service) =>
        {
            var evAttendee = await service.GetByIdAsync(eventId, attendeeId);

            if (evAttendee == null)
                return Results.NotFound(new
                {
                    Error = $"Event Id: {eventId} Attendee Id: {attendeeId} not found"
                });

            await service.DeleteAsync(eventId, attendeeId);
            return Results.Ok(new
            {
                Success = true,
                Data = evAttendee
            });
        });
    }
}