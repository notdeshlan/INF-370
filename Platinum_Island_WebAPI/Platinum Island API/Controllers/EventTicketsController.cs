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
    public class EventTicketsController : ControllerBase
    {
        private readonly Platinum_Island_DatabaseContext _context;

        public EventTicketsController(Platinum_Island_DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/EventTickets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventTicket>>> GetEventTickets()
        {
          if (_context.EventTickets == null)
          {
              return NotFound();
          }
            return await _context.EventTickets.ToListAsync();
        }

        // GET: api/EventTickets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventTicket>> GetEventTicket(int id)
        {
          if (_context.EventTickets == null)
          {
              return NotFound();
          }
            var eventTicket = await _context.EventTickets.FindAsync(id);

            if (eventTicket == null)
            {
                return NotFound();
            }

            return eventTicket;
        }

        // PUT: api/EventTickets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventTicket(int id, EventTicket eventTicket)
        {
            if (id != eventTicket.TicketId)
            {
                return BadRequest();
            }

            _context.Entry(eventTicket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventTicketExists(id))
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

        // POST: api/EventTickets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EventTicket>> PostEventTicket(EventTicket eventTicket)
        {
          if (_context.EventTickets == null)
          {
              return Problem("Entity set 'Platinum_Island_DatabaseContext.EventTickets'  is null.");
          }
            _context.EventTickets.Add(eventTicket);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventTicket", new { id = eventTicket.TicketId }, eventTicket);
        }

        // DELETE: api/EventTickets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventTicket(int id)
        {
            if (_context.EventTickets == null)
            {
                return NotFound();
            }
            var eventTicket = await _context.EventTickets.FindAsync(id);
            if (eventTicket == null)
            {
                return NotFound();
            }

            _context.EventTickets.Remove(eventTicket);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventTicketExists(int id)
        {
            return (_context.EventTickets?.Any(e => e.TicketId == id)).GetValueOrDefault();
        }
    }
}
