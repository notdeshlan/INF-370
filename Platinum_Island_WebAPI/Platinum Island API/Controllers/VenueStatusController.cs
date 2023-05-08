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
    public class VenueStatusController : ControllerBase
    {
        private readonly Platinum_Island_DatabaseContext _context;

        public VenueStatusController(Platinum_Island_DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/VenueStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VenueStatus>>> GetVenueStatuses()
        {
          if (_context.VenueStatuses == null)
          {
              return NotFound();
          }
            return await _context.VenueStatuses.ToListAsync();
        }

        // GET: api/VenueStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VenueStatus>> GetVenueStatus(int id)
        {
          if (_context.VenueStatuses == null)
          {
              return NotFound();
          }
            var venueStatus = await _context.VenueStatuses.FindAsync(id);

            if (venueStatus == null)
            {
                return NotFound();
            }

            return venueStatus;
        }

        // PUT: api/VenueStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVenueStatus(int id, VenueStatus venueStatus)
        {
            if (id != venueStatus.VenueStatusId)
            {
                return BadRequest();
            }

            _context.Entry(venueStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VenueStatusExists(id))
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

        // POST: api/VenueStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VenueStatus>> PostVenueStatus(VenueStatus venueStatus)
        {
          if (_context.VenueStatuses == null)
          {
              return Problem("Entity set 'Platinum_Island_DatabaseContext.VenueStatuses'  is null.");
          }
            _context.VenueStatuses.Add(venueStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVenueStatus", new { id = venueStatus.VenueStatusId }, venueStatus);
        }

        // DELETE: api/VenueStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVenueStatus(int id)
        {
            if (_context.VenueStatuses == null)
            {
                return NotFound();
            }
            var venueStatus = await _context.VenueStatuses.FindAsync(id);
            if (venueStatus == null)
            {
                return NotFound();
            }

            _context.VenueStatuses.Remove(venueStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VenueStatusExists(int id)
        {
            return (_context.VenueStatuses?.Any(e => e.VenueStatusId == id)).GetValueOrDefault();
        }
    }
}
