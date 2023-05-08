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
    public class VenueDateTimesController : ControllerBase
    {
        private readonly Platinum_Island_DatabaseContext _context;

        public VenueDateTimesController(Platinum_Island_DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/VenueDateTimes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VenueDateTime>>> GetVenueDateTimes()
        {
          if (_context.VenueDateTimes == null)
          {
              return NotFound();
          }
            return await _context.VenueDateTimes.ToListAsync();
        }

        // GET: api/VenueDateTimes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VenueDateTime>> GetVenueDateTime(int id)
        {
          if (_context.VenueDateTimes == null)
          {
              return NotFound();
          }
            var venueDateTime = await _context.VenueDateTimes.FindAsync(id);

            if (venueDateTime == null)
            {
                return NotFound();
            }

            return venueDateTime;
        }

        // PUT: api/VenueDateTimes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVenueDateTime(int id, VenueDateTime venueDateTime)
        {
            if (id != venueDateTime.DateId)
            {
                return BadRequest();
            }

            _context.Entry(venueDateTime).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VenueDateTimeExists(id))
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

        // POST: api/VenueDateTimes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VenueDateTime>> PostVenueDateTime(VenueDateTime venueDateTime)
        {
          if (_context.VenueDateTimes == null)
          {
              return Problem("Entity set 'Platinum_Island_DatabaseContext.VenueDateTimes'  is null.");
          }
            _context.VenueDateTimes.Add(venueDateTime);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VenueDateTimeExists(venueDateTime.DateId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVenueDateTime", new { id = venueDateTime.DateId }, venueDateTime);
        }

        // DELETE: api/VenueDateTimes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVenueDateTime(int id)
        {
            if (_context.VenueDateTimes == null)
            {
                return NotFound();
            }
            var venueDateTime = await _context.VenueDateTimes.FindAsync(id);
            if (venueDateTime == null)
            {
                return NotFound();
            }

            _context.VenueDateTimes.Remove(venueDateTime);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VenueDateTimeExists(int id)
        {
            return (_context.VenueDateTimes?.Any(e => e.DateId == id)).GetValueOrDefault();
        }
    }
}
