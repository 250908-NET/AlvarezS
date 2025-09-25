using System.ComponentModel.DataAnnotations;
namespace EventManager.DTOs
{
    public class EventUpdateDto
    {
        [MaxLength(50)]
        public string? Title { get; set; } = null!;

        [MaxLength(100)]
        public string? Description { get; set; } = null!;

        [MaxLength(200)]
        public string? Location { get; set; } = null!;
        
        public DateTime? StartDateTime { get; set; } = null!;

        public DateTime? EndDateTime { get; set; } = null!;
    }
}