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
    public class EventRefundsController : ControllerBase
    {
        private readonly Platinum_Island_DatabaseContext _context;

        public EventRefundsController(Platinum_Island_DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/EventRefunds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventRefund>>> GetEventRefunds()
        {
          if (_context.EventRefunds == null)
          {
              return NotFound();
          }
            return await _context.EventRefunds.ToListAsync();
        }

        // GET: api/EventRefunds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventRefund>> GetEventRefund(int id)
        {
          if (_context.EventRefunds == null)
          {
              return NotFound();
          }
            var eventRefund = await _context.EventRefunds.FindAsync(id);

            if (eventRefund == null)
            {
                return NotFound();
            }

            return eventRefund;
        }

        // PUT: api/EventRefunds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventRefund(int id, EventRefund eventRefund)
        {
            if (id != eventRefund.RefundId)
            {
                return BadRequest();
            }

            _context.Entry(eventRefund).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventRefundExists(id))
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

        // POST: api/EventRefunds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EventRefund>> PostEventRefund(EventRefund eventRefund)
        {
          if (_context.EventRefunds == null)
          {
              return Problem("Entity set 'Platinum_Island_DatabaseContext.EventRefunds'  is null.");
          }
            _context.EventRefunds.Add(eventRefund);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventRefund", new { id = eventRefund.RefundId }, eventRefund);
        }

        // DELETE: api/EventRefunds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventRefund(int id)
        {
            if (_context.EventRefunds == null)
            {
                return NotFound();
            }
            var eventRefund = await _context.EventRefunds.FindAsync(id);
            if (eventRefund == null)
            {
                return NotFound();
            }

            _context.EventRefunds.Remove(eventRefund);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventRefundExists(int id)
        {
            return (_context.EventRefunds?.Any(e => e.RefundId == id)).GetValueOrDefault();
        }
    }
}
