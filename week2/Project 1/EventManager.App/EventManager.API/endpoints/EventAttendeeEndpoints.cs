using Microsoft.AspNetCore.Mvc;
public static class EventAttendeeEndpoints
{
    public static void mapEventAttendeeEndpoints(this IEndpointRouteBuilder app)
    {
        //Register an Attendee to an event
        app.MapPost("/events/{eventId}/Attendee/{attendeeId}", (int eventId, int attendeeId) =>
        {

        });
        
        //Get all Attendees at an Event 
        app.MapGet("/event/{id}/attendees", () =>
        {

        });

        //Get all Events Attendee is signed up for
        app.MapGet("/attendee/{id}/events", (int id) =>
        {

        });
        
        //Delete Attendee from Event
        app.MapDelete("/events/{eventId}/Attendees/{attendeeId}", (int eventId, int attendeeId) =>
        {

        });
    }
}