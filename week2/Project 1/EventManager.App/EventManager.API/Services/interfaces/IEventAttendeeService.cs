using EventManager.Models;
using EventManager.DTOs;

namespace EventManager.Services
{
    public interface IEventAttendeeService
    {
        public Task CreateAsync(int eventId, int attendeeId);
        public Task DeleteAsync(int eventId, int attendeeId);
        public Task<List<EventAttendee>> GetAllAsync();
        public Task<EventAttendee?> GetByIdAsync(int eventId, int attendeeId);
        public Task<List<Attendee>> GetAttendeesByEventIdAsync(int eventId);
        public Task<List<Event>> GetEventsByAttendeeIdAsync(int attendeeId);
        public Task<bool> EventExistsAsync(int eventId);
        public Task<bool> AttendeeExistsAsync(int attendeeId);


    }
}
