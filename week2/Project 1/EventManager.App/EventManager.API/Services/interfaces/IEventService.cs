using EventManager.DTOs;
using EventManager.Models;

namespace EventManager.Services
{
    public interface IEventService
    {
        public Task<Event> CreateAsync(EventCreateDto ev);
        public Task<Event?> UpdateAsync(int id, EventUpdateDto ev);
        public Task DeleteAsync(int id);        
        public Task<List<Event>> GetAllAsync();
        public Task<Event?> GetByIdAsync(int id);
    }
}
