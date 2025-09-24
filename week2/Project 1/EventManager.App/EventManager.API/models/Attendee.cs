namespace EventManager.Models;
using System.ComponentModel.DataAnnotations;

public class Attendee
{
    public int Id { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required, EmailAddress]
    public string Email { get; set; }

    [Required, Phone]
    public string Phone { get; set; }

    public List<Event> Events { get; set; } = new();
    
    public List<EventAttendee> EventAttendees { get; set; } = new();

}