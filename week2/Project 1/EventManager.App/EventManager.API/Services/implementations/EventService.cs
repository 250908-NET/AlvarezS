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
        
        Task IEventService.CreateAsync(Event ev)
        {
            throw new NotImplementedException();
        }

        Task<List<Event>> IEventService.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<Event?> IEventService.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
