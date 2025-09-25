namespace EventManager.Models;
using System.ComponentModel.DataAnnotations;

public class Attendee
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string FirstName { get; set; } = "";

    [Required]
    public string LastName { get; set; } = "";

    [Required, EmailAddress]
    public string Email { get; set; } = "";

    [Required, Phone]
    public string Phone { get; set; } = "";

    public List<Event> Events { get; set; } = new();

    public List<EventAttendee> EventAttendees { get; set; } = new();

    public Attendee(string firstName, string lastName, string email, string phone)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Phone = phone;
    }
}