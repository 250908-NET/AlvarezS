using System.ComponentModel.DataAnnotations;
namespace EventManager.DTOs
{
    public class EventCreateDto
    {
        [Required, MaxLength(50)]
        public string Title { get; set; } = null!;

        [Required, MaxLength(100)]
        public string Description { get; set; } = null!;

        [Required, MaxLength(200)]
        public string Location { get; set; } = null!;

        [Required]
        public DateTime StartDateTime { get; set; }

        [Required]
        public DateTime EndDateTime { get; set; }
    }    
}