using EventManager.Models;

namespace EventManager.Services
{
    public interface IEventAttendeeService
    {
        public Task<List<EventAttendee>> GetAllAsync();
        public Task<EventAttendee?> GetByIdAsync(int eventId, int attendeeId);
        public Task CreateAsync(EventAttendee eventAttendee);

    }
}
