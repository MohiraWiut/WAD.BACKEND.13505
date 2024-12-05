using Microsoft.EntityFrameworkCore;
using WAD.BACKEND._13505.Models;

namespace WAD.BACKEND._13505.Data
{
    public class EventManagerDbContext:DbContext
    {
        public EventManagerDbContext(DbContextOptions<EventManagerDbContext> options) : base(options) { }

        public DbSet<Event> Events { get; set; }
        public DbSet<EventCategory> EventCategories { get; set; }
    }
}
