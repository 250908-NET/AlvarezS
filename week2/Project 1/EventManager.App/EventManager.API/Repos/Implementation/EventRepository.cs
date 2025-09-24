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
            return await  _context.Events.FirstOrDefaultAsync(ev => ev.Id == id);
        }

        public async Task AddAsync(Event ev)
        {
            await _context.Events.AddAsync(ev);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
