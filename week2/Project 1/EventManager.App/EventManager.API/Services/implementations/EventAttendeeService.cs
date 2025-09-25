using EventManager.DTOs;
using EventManager.Models;
using EventManager.Repos;

namespace EventManager.Services
{
    public class EventAttendeeService : IEventAttendeeService
    {
        private readonly IEventAttendeeRepository _repo;
        private readonly IEventRepository _eventRepo;
        private readonly IAttendeeRepository _attendeeRepo;

        public EventAttendeeService(IEventAttendeeRepository repo, IEventRepository eventRepo, IAttendeeRepository attendeeRepo)
        {
            _repo = repo;
            _eventRepo = eventRepo;
            _attendeeRepo = attendeeRepo;

        }

        async Task IEventAttendeeService.CreateAsync(int eventId, int attendeeId)
        {
            await _repo.AddAsync(eventId, attendeeId);
            await _repo.SaveChangesAsync();
        }

        public async Task DeleteAsync(int eventId, int attendeeId)
        {
            await _repo.DeleteAsync(eventId, attendeeId);
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

        public async Task<List<Attendee>> GetAttendeesByEventIdAsync(int eventId)
        {
            var all = await _repo.GetAllAsync();
            return all.Where(ea => ea.EventId == eventId)
                    .Select(ea => ea.Attendee)
                    .ToList();
        }

        public async Task<List<Event>> GetEventsByAttendeeIdAsync(int attendeeId)
        {
            var all = await _repo.GetAllAsync();
            return all.Where(ea => ea.AttendeeId == attendeeId)
                    .Select(ea => ea.Event)
                    .ToList();
        }

        public async Task<bool> EventExistsAsync(int eventId)
        {
            var ev = await _eventRepo.GetByIdAsync(eventId);
            return ev != null;
        }

        public async Task<bool> AttendeeExistsAsync(int attendeeId)
        {
            var attendee = await _attendeeRepo.GetByIdAsync(attendeeId);
            return attendee != null;
        }
    }
}
