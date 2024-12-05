using WAD.BACKEND._13505.Models;

namespace WAD.BACKEND._13505.Repository
{
    public interface IEventCategoryRepository
    {
        Task<IEnumerable<EventCategory>> GetAllEventCategoriesAsync();
        Task<EventCategory> GetEventCategoryByIdAsync(int id);
        Task AddEventCategoryAsync(EventCategory eventCategory);
        Task UpdateEventCategoryAsync(EventCategory eventCategory);
        Task DeleteEventCategoryAsync(int id);
    }
}
