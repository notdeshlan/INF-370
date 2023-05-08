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
    public class DayVisitTicketsController : ControllerBase
    {
        private readonly Platinum_Island_DatabaseContext _context;

        public DayVisitTicketsController(Platinum_Island_DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/DayVisitTickets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DayVisitTicket>>> GetDayVisitTickets()
        {
          if (_context.DayVisitTickets == null)
          {
              return NotFound();
          }
            return await _context.DayVisitTickets.ToListAsync();
        }

        // GET: api/DayVisitTickets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DayVisitTicket>> GetDayVisitTicket(int id)
        {
          if (_context.DayVisitTickets == null)
          {
              return NotFound();
          }
            var dayVisitTicket = await _context.DayVisitTickets.FindAsync(id);

            if (dayVisitTicket == null)
            {
                return NotFound();
            }

            return dayVisitTicket;
        }

        // PUT: api/DayVisitTickets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDayVisitTicket(int id, DayVisitTicket dayVisitTicket)
        {
            if (id != dayVisitTicket.TicketId)
            {
                return BadRequest();
            }

            _context.Entry(dayVisitTicket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DayVisitTicketExists(id))
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

        // POST: api/DayVisitTickets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DayVisitTicket>> PostDayVisitTicket(DayVisitTicket dayVisitTicket)
        {
          if (_context.DayVisitTickets == null)
          {
              return Problem("Entity set 'Platinum_Island_DatabaseContext.DayVisitTickets'  is null.");
          }
            _context.DayVisitTickets.Add(dayVisitTicket);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDayVisitTicket", new { id = dayVisitTicket.TicketId }, dayVisitTicket);
        }

        // DELETE: api/DayVisitTickets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDayVisitTicket(int id)
        {
            if (_context.DayVisitTickets == null)
            {
                return NotFound();
            }
            var dayVisitTicket = await _context.DayVisitTickets.FindAsync(id);
            if (dayVisitTicket == null)
            {
                return NotFound();
            }

            _context.DayVisitTickets.Remove(dayVisitTicket);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DayVisitTicketExists(int id)
        {
            return (_context.DayVisitTickets?.Any(e => e.TicketId == id)).GetValueOrDefault();
        }
    }
}
