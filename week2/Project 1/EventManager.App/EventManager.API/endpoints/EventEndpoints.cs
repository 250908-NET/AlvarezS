using Microsoft.AspNetCore.Mvc;
public static class EventEndpoints
{
    public static void mapEventEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", () =>
        {

        });

        app.MapPost("/", () =>
        {

        });

        app.MapPut("/", ()=>
        {
            
        });
        
        app.MapDelete("/", () =>
        {

        });
    }
}