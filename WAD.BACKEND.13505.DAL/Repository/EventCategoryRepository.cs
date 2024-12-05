using Microsoft.EntityFrameworkCore;
using WAD.BACKEND._13505.Data;
using WAD.BACKEND._13505.Models;

namespace WAD.BACKEND._13505.Repository
{
    public class EventCategoryRepository:IEventCategoryRepository
    {
        private readonly EventManagerDbContext _context;

        public EventCategoryRepository(EventManagerDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EventCategory>> GetAllEventCategoriesAsync()
        {
            return await _context.EventCategories.ToListAsync();
        }

        public async Task<EventCategory> GetEventCategoryByIdAsync(int id)
        {
            return await _context.EventCategories.FindAsync(id);
        }

        public async Task AddEventCategoryAsync(EventCategory eventCategory)
        {
            _context.EventCategories.Add(eventCategory);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEventCategoryAsync(EventCategory eventCategory)
        {
            _context.EventCategories.Update(eventCategory);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEventCategoryAsync(int id)
        {
            var eventCategory = await _context.EventCategories.FindAsync(id);
            if (eventCategory != null)
            {
                _context.EventCategories.Remove(eventCategory);
                await _context.SaveChangesAsync();
            }
        }
    }
}
