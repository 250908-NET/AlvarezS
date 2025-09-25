using EventManager.DTOs;
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

        async Task<Attendee> IAttendeeService.CreateAsync(AttendeeCreateDto dto)
        {
            var attendee = new Attendee(
                dto.FirstName!,
                dto.LastName!,
                dto.Email!,
                dto.Phone!
            );
            await _repo.AddAsync(attendee);
            await _repo.SaveChangesAsync();
            return attendee; 
        }

        public async Task<Attendee?> UpdateAsync(int id, AttendeeUpdateDto dto)
        {
            var attendee = await _repo.GetByIdAsync(id);
            if (attendee == null) return null;

            // Only update if provided
            if (!string.IsNullOrWhiteSpace(dto.FirstName))
                attendee.FirstName = dto.FirstName;

            if (!string.IsNullOrWhiteSpace(dto.LastName))
                attendee.LastName = dto.LastName;

            if (!string.IsNullOrWhiteSpace(dto.Phone))
                attendee.Phone = dto.Phone;

            if (!string.IsNullOrWhiteSpace(dto.Email))
                attendee.Email = dto.Email;

            await _repo.UpdateAsync(attendee);
            await _repo.SaveChangesAsync();
            return attendee;
        }

        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
            await _repo.SaveChangesAsync();
        }

        async Task<List<Attendee>> IAttendeeService.GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        async Task<Attendee?> IAttendeeService.GetByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }
    }
}
