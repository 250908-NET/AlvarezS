namespace EventManager.Models;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class EventAttendee
{
    public int EventId { get; set; }
    [JsonIgnore]
    public Event Event { get; set; } = null!;
    public int AttendeeId { get; set; }
    [JsonIgnore]
    public Attendee Attendee { get; set; } = null!;

    public EventAttendee(int eventId, int attendeeId)
    {
        EventId = eventId;
        AttendeeId = attendeeId;
    }
}
