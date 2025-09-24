using EventManager.Models;
using EventManager.Data;
using Microsoft.EntityFrameworkCore;

namespace EventManager.Repos
{
    public class EventRepository : IEventRepository
    {
        private readonly EventManagerDbContext _context;

        public EventRepository(EventManagerDbContext context)
        {
            _context = context;
        }

         public async Task<List<Event>> GetAllAsync()
         {
            return await _context.Events.ToListAsync();
         }
         
        public async Task<Event?> GetByIdAsync(int id)
        {
            return await _context.Events.FirstOrDefaultAsync(ev => ev.Id == id);
        }

        public async Task AddAsync(Event ev)
        {
            await _context.Events.AddAsync(ev);
            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Event ev)
        {
            _context.Events.Update(ev);
            await SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var ev = await GetByIdAsync(id);
            if (ev != null)
            {
                _context.Events.Remove(ev);
                await SaveChangesAsync();
            }
        }
    }
}
