using EventManager.Models;

namespace EventManager.Services
{
    public interface IEventService
    {
        public Task<List<Event>> GetAllAsync();
        public Task<Event?> GetByIdAsync(int id);
        public Task CreateAsync(Event ev);
    }
}
