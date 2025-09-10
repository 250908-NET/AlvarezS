public static class DateTimeEndpoints
{
    public static void MapDateTimeEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/date/today", () =>
        {
            DateTime d = DateTime.Now;
            return d.ToShortDateString();
        });

        app.MapGet("/date/age/{birthyear}", (int birthyear) =>
        {
            return DateTime.Now.Year - birthyear;
        });

        app.MapGet("/date/daysbetween/{date1}/{date2}", (string  date1, string date2) =>
        {
            return Math.Abs(DateTime.Parse(date2).Subtract(DateTime.Parse(date1)).TotalDays);
        });

        app.MapGet("/date/weekday/{date}", (string date) =>
        {
            return DateTime.Parse(date).DayOfWeek.ToString();
        });
    }
}