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
    public class DayVisitTicketPricesController : ControllerBase
    {
        private readonly Platinum_Island_DatabaseContext _context;

        public DayVisitTicketPricesController(Platinum_Island_DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/DayVisitTicketPrices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DayVisitTicketPrice>>> GetDayVisitTicketPrices()
        {
          if (_context.DayVisitTicketPrices == null)
          {
              return NotFound();
          }
            return await _context.DayVisitTicketPrices.ToListAsync();
        }

        // GET: api/DayVisitTicketPrices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DayVisitTicketPrice>> GetDayVisitTicketPrice(int id)
        {
          if (_context.DayVisitTicketPrices == null)
          {
              return NotFound();
          }
            var dayVisitTicketPrice = await _context.DayVisitTicketPrices.FindAsync(id);

            if (dayVisitTicketPrice == null)
            {
                return NotFound();
            }

            return dayVisitTicketPrice;
        }

        // PUT: api/DayVisitTicketPrices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDayVisitTicketPrice(int id, DayVisitTicketPrice dayVisitTicketPrice)
        {
            if (id != dayVisitTicketPrice.PriceId)
            {
                return BadRequest();
            }

            _context.Entry(dayVisitTicketPrice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DayVisitTicketPriceExists(id))
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

        // POST: api/DayVisitTicketPrices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DayVisitTicketPrice>> PostDayVisitTicketPrice(DayVisitTicketPrice dayVisitTicketPrice)
        {
          if (_context.DayVisitTicketPrices == null)
          {
              return Problem("Entity set 'Platinum_Island_DatabaseContext.DayVisitTicketPrices'  is null.");
          }
            _context.DayVisitTicketPrices.Add(dayVisitTicketPrice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDayVisitTicketPrice", new { id = dayVisitTicketPrice.PriceId }, dayVisitTicketPrice);
        }

        // DELETE: api/DayVisitTicketPrices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDayVisitTicketPrice(int id)
        {
            if (_context.DayVisitTicketPrices == null)
            {
                return NotFound();
            }
            var dayVisitTicketPrice = await _context.DayVisitTicketPrices.FindAsync(id);
            if (dayVisitTicketPrice == null)
            {
                return NotFound();
            }

            _context.DayVisitTicketPrices.Remove(dayVisitTicketPrice);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DayVisitTicketPriceExists(int id)
        {
            return (_context.DayVisitTicketPrices?.Any(e => e.PriceId == id)).GetValueOrDefault();
        }
    }
}
