using System.ComponentModel.DataAnnotations;
namespace EventManager.DTOs
{
    public class AttendeeCreateDto
    {
        [MaxLength(50)]
        public string? FirstName { get; set; } = null!;

        [MaxLength(50)]
        public string? LastName { get; set; } = null!;

        [EmailAddress]
        public string? Email { get; set; } = null!;

        [Phone]
        public string? Phone { get; set; } = null!;
    }    
}