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
    public class EventPaymentsController : ControllerBase
    {
        private readonly Platinum_Island_DatabaseContext _context;

        public EventPaymentsController(Platinum_Island_DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/EventPayments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventPayment>>> GetEventPayments()
        {
          if (_context.EventPayments == null)
          {
              return NotFound();
          }
            return await _context.EventPayments.ToListAsync();
        }

        // GET: api/EventPayments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventPayment>> GetEventPayment(int id)
        {
          if (_context.EventPayments == null)
          {
              return NotFound();
          }
            var eventPayment = await _context.EventPayments.FindAsync(id);

            if (eventPayment == null)
            {
                return NotFound();
            }

            return eventPayment;
        }

        // PUT: api/EventPayments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventPayment(int id, EventPayment eventPayment)
        {
            if (id != eventPayment.EventPaymentId)
            {
                return BadRequest();
            }

            _context.Entry(eventPayment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventPaymentExists(id))
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

        // POST: api/EventPayments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EventPayment>> PostEventPayment(EventPayment eventPayment)
        {
          if (_context.EventPayments == null)
          {
              return Problem("Entity set 'Platinum_Island_DatabaseContext.EventPayments'  is null.");
          }
            _context.EventPayments.Add(eventPayment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventPayment", new { id = eventPayment.EventPaymentId }, eventPayment);
        }

        // DELETE: api/EventPayments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventPayment(int id)
        {
            if (_context.EventPayments == null)
            {
                return NotFound();
            }
            var eventPayment = await _context.EventPayments.FindAsync(id);
            if (eventPayment == null)
            {
                return NotFound();
            }

            _context.EventPayments.Remove(eventPayment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventPaymentExists(int id)
        {
            return (_context.EventPayments?.Any(e => e.EventPaymentId == id)).GetValueOrDefault();
        }
    }
}
