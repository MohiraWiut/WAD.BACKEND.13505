using WAD.BACKEND._13505.Models;

namespace WAD.BACKEND._13505.Repository
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAllEventsAsync();
        Task<Event> GetEventByIdAsync(int id);
        Task AddEventAsync(Event evnt);
        Task UpdateEventAsync(Event evnt);
        Task DeleteEventAsync(int id);
    }
}
