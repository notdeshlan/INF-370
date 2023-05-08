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
    public class VenuePricesController : ControllerBase
    {
        private readonly Platinum_Island_DatabaseContext _context;

        public VenuePricesController(Platinum_Island_DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/VenuePrices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VenuePrice>>> GetVenuePrices()
        {
          if (_context.VenuePrices == null)
          {
              return NotFound();
          }
            return await _context.VenuePrices.ToListAsync();
        }

        // GET: api/VenuePrices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VenuePrice>> GetVenuePrice(int id)
        {
          if (_context.VenuePrices == null)
          {
              return NotFound();
          }
            var venuePrice = await _context.VenuePrices.FindAsync(id);

            if (venuePrice == null)
            {
                return NotFound();
            }

            return venuePrice;
        }

        // PUT: api/VenuePrices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVenuePrice(int id, VenuePrice venuePrice)
        {
            if (id != venuePrice.VenuePriceId)
            {
                return BadRequest();
            }

            _context.Entry(venuePrice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VenuePriceExists(id))
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

        // POST: api/VenuePrices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VenuePrice>> PostVenuePrice(VenuePrice venuePrice)
        {
          if (_context.VenuePrices == null)
          {
              return Problem("Entity set 'Platinum_Island_DatabaseContext.VenuePrices'  is null.");
          }
            _context.VenuePrices.Add(venuePrice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVenuePrice", new { id = venuePrice.VenuePriceId }, venuePrice);
        }

        // DELETE: api/VenuePrices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVenuePrice(int id)
        {
            if (_context.VenuePrices == null)
            {
                return NotFound();
            }
            var venuePrice = await _context.VenuePrices.FindAsync(id);
            if (venuePrice == null)
            {
                return NotFound();
            }

            _context.VenuePrices.Remove(venuePrice);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VenuePriceExists(int id)
        {
            return (_context.VenuePrices?.Any(e => e.VenuePriceId == id)).GetValueOrDefault();
        }
    }
}
