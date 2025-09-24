using EventManager.Models;
using EventManager.Repos;

namespace EventManager.Services
{
    public class AttendeeService : IAttendeeService
    {
        private readonly IAttendeeRepository _repo;

        public AttendeeService(IAttendeeRepository repo)
        {
            _repo = repo;
        }

        Task IAttendeeService.CreateAsync(Attendee attendee)
        {
            throw new NotImplementedException();
        }

        Task<List<Attendee>> IAttendeeService.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<Attendee?> IAttendeeService.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
