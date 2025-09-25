using EventManager.Models;

namespace EventManager.Repos
{
    public interface IEventAttendeeRepository
    {
        public Task AddAsync(int eventId, int attendeeId);
        public Task DeleteAsync(int eventId, int attendeeId);
        public Task<List<EventAttendee>> GetAllAsync();
        public Task<EventAttendee?> GetByIdAsync(int eventId, int attendeeId);
        public Task SaveChangesAsync();
    }
}