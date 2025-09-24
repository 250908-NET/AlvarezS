using EventManager.Models;

namespace EventManager.Repos
{
    public interface IEventRepository
    {
        public Task<List<Event>> GetAllAsync();
        public Task<Event?> GetByIdAsync(int id);
        public Task AddAsync(Event ev);
        public Task SaveChangesAsync();
        public Task UpdateAsync(Event ev);
        public Task DeleteAsync(int id);
    }
}