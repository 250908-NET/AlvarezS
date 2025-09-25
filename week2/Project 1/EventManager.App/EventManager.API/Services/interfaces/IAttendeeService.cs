using EventManager.DTOs;
using EventManager.Models;

namespace EventManager.Services
{
    public interface IAttendeeService
    {
        public Task<Attendee> CreateAsync(AttendeeCreateDto dto);
         public Task<Attendee?> UpdateAsync(int id, AttendeeUpdateDto dto);
         public Task DeleteAsync(int id);       
        public Task<List<Attendee>> GetAllAsync();
        public Task<Attendee?> GetByIdAsync(int id);
    }
}
