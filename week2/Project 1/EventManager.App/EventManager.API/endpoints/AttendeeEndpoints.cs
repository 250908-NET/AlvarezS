using Microsoft.AspNetCore.Mvc;
using EventManager.DTOs;
public static class AttendeeEndpoints
{
    
    public static void mapAttendeeEndpoints(this IEndpointRouteBuilder app)
    {
        //Register an attendee
        app.MapPost("/attendees", () =>
        {

        });

        //Get all attendees (show list of  id + attendee names)
        app.MapGet("/attendees", () =>
        {

        });

        //Get attendee by id (show all attendee info)
        app.MapGet("/attendees/{id}", (int id) =>
        {

        });

        //Update attendee details
        app.MapPut("/attendees/{id}", (int id) =>
        {

        });

        //Delete attendee by id
        app.MapDelete("/attendees/{id}", (int id) =>
        {

        });
    }
}