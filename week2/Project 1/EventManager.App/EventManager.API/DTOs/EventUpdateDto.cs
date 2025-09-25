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
        
        [DataType(DataType.Date)]
        public string? StartDate { get; set; } = null!;

        [DataType(DataType.Date)]
        public string? EndDate { get; set; } = null!;

        [DataType(DataType.Time)]
        public string? StartTime { get; set; } = null!;

        [DataType(DataType.Time)]
        public string? EndTime { get; set; } = null!;
    }
}