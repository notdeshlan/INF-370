using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Platinum_Island_API.Models;

namespace Platinum_Island_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventStatusController : ControllerBase
    {
        private readonly Platinum_Island_DatabaseContext _context;

        public EventStatusController(Platinum_Island_DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/EventStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventStatus>>> GetEventStatuses()
        {
          if (_context.EventStatuses == null)
          {
              return NotFound();
          }
            return await _context.EventStatuses.ToListAsync();
        }

        // GET: api/EventStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventStatus>> GetEventStatus(int id)
        {
          if (_context.EventStatuses == null)
          {
              return NotFound();
          }
            var eventStatus = await _context.EventStatuses.FindAsync(id);

            if (eventStatus == null)
            {
                return NotFound();
            }

            return eventStatus;
        }

        // PUT: api/EventStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventStatus(int id, EventStatus eventStatus)
        {
            if (id != eventStatus.EventStatusId)
            {
                return BadRequest();
            }

            _context.Entry(eventStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventStatusExists(id))
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

        // POST: api/EventStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EventStatus>> PostEventStatus(EventStatus eventStatus)
        {
          if (_context.EventStatuses == null)
          {
              return Problem("Entity set 'Platinum_Island_DatabaseContext.EventStatuses'  is null.");
          }
            _context.EventStatuses.Add(eventStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventStatus", new { id = eventStatus.EventStatusId }, eventStatus);
        }

        // DELETE: api/EventStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventStatus(int id)
        {
            if (_context.EventStatuses == null)
            {
                return NotFound();
            }
            var eventStatus = await _context.EventStatuses.FindAsync(id);
            if (eventStatus == null)
            {
                return NotFound();
            }

            _context.EventStatuses.Remove(eventStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventStatusExists(int id)
        {
            return (_context.EventStatuses?.Any(e => e.EventStatusId == id)).GetValueOrDefault();
        }
    }
}
