using Microsoft.EntityFrameworkCore;
using WAD.BACKEND._13505.Data;
using WAD.BACKEND._13505.Models;

namespace WAD.BACKEND._13505.Repository
{
    public class EventRepository:IEventRepository
    {
        private readonly EventManagerDbContext _context;

        public EventRepository(EventManagerDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Event>> GetAllEventsAsync()
        {
            return await _context.Events
                                 .Include(e => e.EventCategory)
                                 .ToListAsync();
        }

        public async Task<Event> GetEventByIdAsync(int id)
        {
            return await _context.Events
                                 .Include(e => e.EventCategory)
                                 .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task AddEventAsync(Event evnt)
        {
            _context.Events.Add(evnt);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEventAsync(Event evnt)
        {
            _context.Events.Update(evnt);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEventAsync(int id)
        {
            var evnt = await _context.Events.FindAsync(id);
            if (evnt != null)
            {
                _context.Events.Remove(evnt);
                await _context.SaveChangesAsync();
            }
        }
    }
}
