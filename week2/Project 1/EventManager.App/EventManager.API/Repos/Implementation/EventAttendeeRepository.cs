using EventManager.Models;
using EventManager.Data;
using Microsoft.EntityFrameworkCore;

namespace EventManager.Repos
{
    public class EventAttendeeRepository : IEventAttendeeRepository
    {
        private readonly EventManagerDbContext _context;

        public EventAttendeeRepository(EventManagerDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(int eventId, int attendeeId)
        {
            var eventAttendee = new EventAttendee(eventId, attendeeId);
            await _context.EventAttendees.AddAsync(eventAttendee);
            await SaveChangesAsync();
        }

        public async Task DeleteAsync(int eventId, int attendeeId)
        {
            var ev = await GetByIdAsync(eventId, attendeeId);
            if (ev != null)
            {
                _context.EventAttendees.Remove(ev);
                await SaveChangesAsync();
            }
        }
        public async Task<List<EventAttendee>> GetAllAsync()
        {
            return await _context.EventAttendees
                        .Include(ea => ea.Attendee)
                        .Include(ea => ea.Event)
                        .ToListAsync();
        }

        public async Task<EventAttendee?> GetByIdAsync(int eventId, int attendeeId)
        {
            return await  _context.EventAttendees.FirstOrDefaultAsync(EventAttendee => EventAttendee.EventId == eventId && EventAttendee.AttendeeId == attendeeId);
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}