using Microsoft.AspNetCore.Mvc;
public static class EventEndpoints
{
    public static void mapEventEndpoints(this IEndpointRouteBuilder app)
    {
        //Register an event
        app.MapPost("/events", () =>
        {

        });

        //Get all events (show list of  id + event names + descriptions)
        app.MapGet("/events", () =>
        {

        });

        //Get event by id (show all event info)
        app.MapGet("/events/{id}", (int id) =>
        {

        });

        //Update event details
        app.MapPut("/events/{id}", (int id)=>
        {
            
        });
        
        //Delete event by id
        app.MapDelete("/events/{id}", (int id) =>
        {

        });
    }
}