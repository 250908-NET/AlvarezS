using EventManager.Models;

namespace EventManager.Repos
{
    public interface IEventAttendeeRepository
    {
        public Task<List<EventAttendee>> GetAllAsync();
        public Task<EventAttendee?> GetByIdAsync(int eventId, int attendeeId);
        public Task AddAsync(EventAttendee eventAttendee);
        public Task SaveChangesAsync();
        public Task DeleteAsync(int eventId, int attendeeId);
    }
}