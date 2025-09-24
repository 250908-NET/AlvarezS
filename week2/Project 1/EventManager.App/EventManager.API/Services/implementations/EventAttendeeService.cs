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
        
        Task IEventAttendeeService.CreateAsync(EventAttendee eventAttendee)
        {
            throw new NotImplementedException();
        }

        Task<List<EventAttendee>> IEventAttendeeService.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<EventAttendee?> IEventAttendeeService.GetByIdAsync(int eventId, int attendeeId)
        {
            throw new NotImplementedException();
        }
    }
}
