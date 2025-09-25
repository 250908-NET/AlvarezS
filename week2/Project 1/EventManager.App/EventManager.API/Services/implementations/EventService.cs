using EventManager.Models;
using EventManager.Repos;
using EventManager.DTOs;

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

        public async Task<Event?> UpdateAsync(int id, EventUpdateDto dto)
        {
            var ev = await _repo.GetByIdAsync(id);
            if (ev == null) return null;

            // Only update if provided
            if (!string.IsNullOrWhiteSpace(dto.Title))
                ev.Title = dto.Title;

            if (!string.IsNullOrWhiteSpace(dto.Description))
                ev.Description = dto.Description;

            if (!string.IsNullOrWhiteSpace(dto.Location))
                ev.Location = dto.Location;

            // Update StartDateTime if either date or time is provided
            if (!string.IsNullOrWhiteSpace(dto.StartDate) || !string.IsNullOrWhiteSpace(dto.StartTime))
            {
                var date = string.IsNullOrWhiteSpace(dto.StartDate) ? ev.StartDateTime.Date : DateTime.Parse(dto.StartDate);
                var time = string.IsNullOrWhiteSpace(dto.StartTime) ? ev.StartDateTime.TimeOfDay : TimeSpan.Parse(dto.StartTime);
                ev.StartDateTime = date.Add(time);
            }

            // Update EndDateTime similarly
            if (!string.IsNullOrWhiteSpace(dto.EndDate) || !string.IsNullOrWhiteSpace(dto.EndTime))
            {
                var date = string.IsNullOrWhiteSpace(dto.EndDate) ? ev.EndDateTime.Date : DateTime.Parse(dto.EndDate);
                var time = string.IsNullOrWhiteSpace(dto.EndTime) ? ev.EndDateTime.TimeOfDay : TimeSpan.Parse(dto.EndTime);
                ev.EndDateTime = date.Add(time);
            }

            await _repo.UpdateAsync(ev);
            await _repo.SaveChangesAsync();
            return ev;
        }

        async Task<Event> IEventService.CreateAsync(EventCreateDto dto)
        {
            var StartDate = DateTime.Parse(dto.StartDate!); // "YYYY-MM-DD"
            var EndDate = DateTime.Parse(dto.EndDate!); // "YYYY-MM-DD"
            var start = TimeSpan.Parse(dto.StartTime!); // "HH:mm"
            var end = TimeSpan.Parse(dto.EndTime!);     // "HH:mm"

            var ev = new Event(
                dto.Title!,
                dto.Description!,
                dto.Location!,
                StartDate.Add(start),
                EndDate.Add(end)
            );
            await _repo.AddAsync(ev);
            await _repo.SaveChangesAsync();
            return ev;            
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
