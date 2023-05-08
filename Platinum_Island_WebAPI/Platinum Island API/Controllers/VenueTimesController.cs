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
    public class VenueTimesController : ControllerBase
    {
        private readonly Platinum_Island_DatabaseContext _context;

        public VenueTimesController(Platinum_Island_DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/VenueTimes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VenueTime>>> GetVenueTimes()
        {
          if (_context.VenueTimes == null)
          {
              return NotFound();
          }
            return await _context.VenueTimes.ToListAsync();
        }

        // GET: api/VenueTimes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VenueTime>> GetVenueTime(int id)
        {
          if (_context.VenueTimes == null)
          {
              return NotFound();
          }
            var venueTime = await _context.VenueTimes.FindAsync(id);

            if (venueTime == null)
            {
                return NotFound();
            }

            return venueTime;
        }

        // PUT: api/VenueTimes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVenueTime(int id, VenueTime venueTime)
        {
            if (id != venueTime.VenueTimeId)
            {
                return BadRequest();
            }

            _context.Entry(venueTime).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VenueTimeExists(id))
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

        // POST: api/VenueTimes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VenueTime>> PostVenueTime(VenueTime venueTime)
        {
          if (_context.VenueTimes == null)
          {
              return Problem("Entity set 'Platinum_Island_DatabaseContext.VenueTimes'  is null.");
          }
            _context.VenueTimes.Add(venueTime);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVenueTime", new { id = venueTime.VenueTimeId }, venueTime);
        }

        // DELETE: api/VenueTimes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVenueTime(int id)
        {
            if (_context.VenueTimes == null)
            {
                return NotFound();
            }
            var venueTime = await _context.VenueTimes.FindAsync(id);
            if (venueTime == null)
            {
                return NotFound();
            }

            _context.VenueTimes.Remove(venueTime);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VenueTimeExists(int id)
        {
            return (_context.VenueTimes?.Any(e => e.VenueTimeId == id)).GetValueOrDefault();
        }
    }
}
