using EventManager.Models;
using EventManager.Repos;

namespace EventManager.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _repo;

        public EventService(IEventRepository repo)
        {
            _repo = repo;
        }

        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
            await _repo.SaveChangesAsync();
        }

        public async Task UpdateAsync(Event ev)
        {
            await _repo.UpdateAsync(ev);
            await _repo.SaveChangesAsync();
        }

        async Task IEventService.CreateAsync(Event ev)
        {
            await _repo.AddAsync(ev);
            await _repo.SaveChangesAsync();            
        }

        async Task<List<Event>> IEventService.GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        async Task<Event?> IEventService.GetByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }
    }
}
