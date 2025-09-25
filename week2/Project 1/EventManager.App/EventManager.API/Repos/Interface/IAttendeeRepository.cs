using EventManager.Models;

namespace EventManager.Repos
{
    public interface IAttendeeRepository
    {
        public Task AddAsync(Attendee attendee);
        public Task UpdateAsync(Attendee attendee);
        public Task DeleteAsync(int id);
        public Task<List<Attendee>> GetAllAsync();
        public Task<Attendee?> GetByIdAsync(int id);
        public Task SaveChangesAsync();
    }
}