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
    public class VenueInspectionWriteOffsController : ControllerBase
    {
        private readonly Platinum_Island_DatabaseContext _context;

        public VenueInspectionWriteOffsController(Platinum_Island_DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/VenueInspectionWriteOffs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VenueInspectionWriteOff>>> GetVenueInspectionWriteOffs()
        {
          if (_context.VenueInspectionWriteOffs == null)
          {
              return NotFound();
          }
            return await _context.VenueInspectionWriteOffs.ToListAsync();
        }

        // GET: api/VenueInspectionWriteOffs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VenueInspectionWriteOff>> GetVenueInspectionWriteOff(int id)
        {
          if (_context.VenueInspectionWriteOffs == null)
          {
              return NotFound();
          }
            var venueInspectionWriteOff = await _context.VenueInspectionWriteOffs.FindAsync(id);

            if (venueInspectionWriteOff == null)
            {
                return NotFound();
            }

            return venueInspectionWriteOff;
        }

        // PUT: api/VenueInspectionWriteOffs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVenueInspectionWriteOff(int id, VenueInspectionWriteOff venueInspectionWriteOff)
        {
            if (id != venueInspectionWriteOff.ItemId)
            {
                return BadRequest();
            }

            _context.Entry(venueInspectionWriteOff).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VenueInspectionWriteOffExists(id))
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

        // POST: api/VenueInspectionWriteOffs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VenueInspectionWriteOff>> PostVenueInspectionWriteOff(VenueInspectionWriteOff venueInspectionWriteOff)
        {
          if (_context.VenueInspectionWriteOffs == null)
          {
              return Problem("Entity set 'Platinum_Island_DatabaseContext.VenueInspectionWriteOffs'  is null.");
          }
            _context.VenueInspectionWriteOffs.Add(venueInspectionWriteOff);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VenueInspectionWriteOffExists(venueInspectionWriteOff.ItemId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVenueInspectionWriteOff", new { id = venueInspectionWriteOff.ItemId }, venueInspectionWriteOff);
        }

        // DELETE: api/VenueInspectionWriteOffs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVenueInspectionWriteOff(int id)
        {
            if (_context.VenueInspectionWriteOffs == null)
            {
                return NotFound();
            }
            var venueInspectionWriteOff = await _context.VenueInspectionWriteOffs.FindAsync(id);
            if (venueInspectionWriteOff == null)
            {
                return NotFound();
            }

            _context.VenueInspectionWriteOffs.Remove(venueInspectionWriteOff);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VenueInspectionWriteOffExists(int id)
        {
            return (_context.VenueInspectionWriteOffs?.Any(e => e.ItemId == id)).GetValueOrDefault();
        }
    }
}
