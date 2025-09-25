using EventManager.Models;
using EventManager.Data;
using Microsoft.EntityFrameworkCore;

namespace EventManager.Repos
{
    public class AttendeeRepository : IAttendeeRepository
    {
        private readonly EventManagerDbContext _context;

        public AttendeeRepository(EventManagerDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Attendee attendee)
        {
            await _context.Attendees.AddAsync(attendee);
            await SaveChangesAsync();
        }

        public async Task UpdateAsync(Attendee attendee)
        {
            _context.Attendees.Update(attendee);
            await SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var attendee = await GetByIdAsync(id);
            if (attendee != null)
            {
                _context.Attendees.Remove(attendee);
                await SaveChangesAsync();
            }
        }

        public async Task<List<Attendee>> GetAllAsync()
        {
            return await _context.Attendees.ToListAsync();
        }

        public async Task<Attendee?> GetByIdAsync(int id)
        {
            return await  _context.Attendees.FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
