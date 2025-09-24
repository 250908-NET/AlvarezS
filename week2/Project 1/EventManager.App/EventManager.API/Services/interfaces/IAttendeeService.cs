using EventManager.Models;

namespace EventManager.Services
{
    public interface IAttendeeService
    {
        public Task<List<Attendee>> GetAllAsync();
        public Task<Attendee?> GetByIdAsync(int id);
        public Task CreateAsync(Attendee attendee);
         public Task UpdateAsync(Attendee attendee);
         public Task DeleteAsync(int id);       
    }
}
