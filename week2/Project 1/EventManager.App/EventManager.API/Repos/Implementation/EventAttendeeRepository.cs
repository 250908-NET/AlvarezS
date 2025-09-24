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

        public async Task<List<EventAttendee>> GetAllAsync()
        {
           return await _context.EventAttendees.ToListAsync();
        }

        public async Task<EventAttendee?> GetByIdAsync(int eventId, int attendeeId)
        {
            return await  _context.EventAttendees.FirstOrDefaultAsync(EventAttendee => EventAttendee.EventId == eventId && EventAttendee.AttendeeId == attendeeId);
        }

        public async Task AddAsync(EventAttendee eventAttendee)
        {
            await _context.EventAttendees.AddAsync(eventAttendee);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}