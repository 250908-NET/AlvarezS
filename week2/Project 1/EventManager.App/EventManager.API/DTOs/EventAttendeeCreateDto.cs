using System.ComponentModel.DataAnnotations;
namespace EventManager.DTOs
{
    public class EventAttendeeCreateDto
    {
        public int? EventId { get; set; } = null!;
        public string? EventTitle { get; set; } = null!;
        public int? AttendeeId { get; set; } = null!;
        public string? AttendeeFullName { get; set; } = null!;
    }    
}