using EventManager.Models;

namespace EventManager.Repos
{
    public interface IEventRepository
    {
        public Task AddAsync(Event ev);
        public Task UpdateAsync(Event ev);
        public Task DeleteAsync(int id);
        public Task<List<Event>> GetAllAsync();
        public Task<Event?> GetByIdAsync(int id);
        public Task SaveChangesAsync();
    }
}