using EventManager.Models;

namespace EventManager.Repos
{
    public interface IAttendeeRepository
    {
        public Task<List<Attendee>> GetAllAsync();
        public Task<Attendee?> GetByIdAsync(int id);
        public Task AddAsync(Attendee attendee);
        public Task SaveChangesAsync();
    }
}