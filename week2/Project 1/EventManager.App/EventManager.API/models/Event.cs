namespace EventManager.Models;

using System.ComponentModel.DataAnnotations;

public class Event
{
    public int Id { get; set; }

    [Required, MaxLength(50)]
    public string Title { get; set; }

    [Required, MaxLength(100)]
    public string Description { get; set; }

    [Required, MaxLength(200)]
    public string Location { get; set; }

    [Required]
    public DateTime StartDateTime { get; set; }

    [Required]
    public DateTime EndDateTime { get; set; }

    public List<EventAttendee> EventAttendees { get; set; } = new();
}