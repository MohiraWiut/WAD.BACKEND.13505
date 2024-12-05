using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WAD.BACKEND._13505.Data;
using WAD.BACKEND._13505.Models;

namespace WAD.BACKEND._13505.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly EventManagerDbContext _context;

        public EventsController(EventManagerDbContext context)
        {
            _context = context;
        }

        // GET: api/Events
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
        {
            return await _context.Events
                                 .Include(e => e.EventCategory) 
                                 .ToListAsync();
        }

        // GET: api/Events/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEvent(int id)
        {
            var evnt = await _context.Events
                                      .Include(e => e.EventCategory) 
                                      .FirstOrDefaultAsync(e => e.Id == id);

            if (evnt == null)
            {
                return NotFound();
            }

            return evnt;
        }

        // PUT: api/Events/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent(int id, Event evnt)
        {
            if (id != evnt.Id)
            {
                return BadRequest();
            }

            var eventCategory = await _context.EventCategories.FindAsync(evnt.EventCategoryId);
            if (eventCategory == null)
            {
                return BadRequest(new { message = "Invalid EventCategoryId. Category does not exist." });
            }

            evnt.EventCategory = eventCategory;

            _context.Entry(evnt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Events
        [HttpPost]
        public async Task<ActionResult<Event>> PostEvent(Event evnt)
        {
            var eventCategory = await _context.EventCategories.FindAsync(evnt.EventCategoryId);
            if (eventCategory == null)
            {
                return BadRequest(new { message = "Invalid EventCategoryId. Category does not exist." });
            }

            evnt.EventCategory = eventCategory;

            _context.Events.Add(evnt);
            await _context.SaveChangesAsync();

            var createdEvent = await _context.Events
                                             .Include(e => e.EventCategory) 
                                             .FirstOrDefaultAsync(e => e.Id == evnt.Id);

            return CreatedAtAction("GetEvent", new { id = createdEvent.Id }, createdEvent);
        }

        // DELETE: api/Events/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var evnt = await _context.Events.FindAsync(id);
            if (evnt == null)
            {
                return NotFound();
            }

            _context.Events.Remove(evnt);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.Id == id);
        }
    }
}
