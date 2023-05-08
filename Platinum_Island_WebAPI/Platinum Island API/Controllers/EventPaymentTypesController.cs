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
    public class EventPaymentTypesController : ControllerBase
    {
        private readonly Platinum_Island_DatabaseContext _context;

        public EventPaymentTypesController(Platinum_Island_DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/EventPaymentTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventPaymentType>>> GetEventPaymentTypes()
        {
          if (_context.EventPaymentTypes == null)
          {
              return NotFound();
          }
            return await _context.EventPaymentTypes.ToListAsync();
        }

        // GET: api/EventPaymentTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventPaymentType>> GetEventPaymentType(int id)
        {
          if (_context.EventPaymentTypes == null)
          {
              return NotFound();
          }
            var eventPaymentType = await _context.EventPaymentTypes.FindAsync(id);

            if (eventPaymentType == null)
            {
                return NotFound();
            }

            return eventPaymentType;
        }

        // PUT: api/EventPaymentTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventPaymentType(int id, EventPaymentType eventPaymentType)
        {
            if (id != eventPaymentType.PaymentTypeId)
            {
                return BadRequest();
            }

            _context.Entry(eventPaymentType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventPaymentTypeExists(id))
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

        // POST: api/EventPaymentTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EventPaymentType>> PostEventPaymentType(EventPaymentType eventPaymentType)
        {
          if (_context.EventPaymentTypes == null)
          {
              return Problem("Entity set 'Platinum_Island_DatabaseContext.EventPaymentTypes'  is null.");
          }
            _context.EventPaymentTypes.Add(eventPaymentType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventPaymentType", new { id = eventPaymentType.PaymentTypeId }, eventPaymentType);
        }

        // DELETE: api/EventPaymentTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventPaymentType(int id)
        {
            if (_context.EventPaymentTypes == null)
            {
                return NotFound();
            }
            var eventPaymentType = await _context.EventPaymentTypes.FindAsync(id);
            if (eventPaymentType == null)
            {
                return NotFound();
            }

            _context.EventPaymentTypes.Remove(eventPaymentType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventPaymentTypeExists(int id)
        {
            return (_context.EventPaymentTypes?.Any(e => e.PaymentTypeId == id)).GetValueOrDefault();
        }
    }
}
