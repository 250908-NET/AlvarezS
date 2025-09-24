using EventManager.Models;
using EventManager.Repos;

namespace EventManager.Services
{
    public class EventAttendeeService : IEventAttendeeService
    {
        private readonly IEventAttendeeRepository _repo;

        public EventAttendeeService(IEventAttendeeRepository repo)
        {
            _repo = repo;
        }

        public async Task DeleteAsync(int eventId, int attendeeId)
        {
            await _repo.DeleteAsync(eventId, attendeeId);
            await _repo.SaveChangesAsync();
        }

        async Task IEventAttendeeService.CreateAsync(EventAttendee eventAttendee)
        {
            await _repo.AddAsync(eventAttendee);
            await _repo.SaveChangesAsync();
        }

        async Task<List<EventAttendee>> IEventAttendeeService.GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        async Task<EventAttendee?> IEventAttendeeService.GetByIdAsync(int eventId, int attendeeId)
        {
            return await _repo.GetByIdAsync(eventId, attendeeId);

        }
    }
}
