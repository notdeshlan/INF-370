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
    public class VenueInspectionsController : ControllerBase
    {
        private readonly Platinum_Island_DatabaseContext _context;

        public VenueInspectionsController(Platinum_Island_DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/VenueInspections
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VenueInspection>>> GetVenueInspections()
        {
          if (_context.VenueInspections == null)
          {
              return NotFound();
          }
            return await _context.VenueInspections.ToListAsync();
        }

        // GET: api/VenueInspections/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VenueInspection>> GetVenueInspection(int id)
        {
          if (_context.VenueInspections == null)
          {
              return NotFound();
          }
            var venueInspection = await _context.VenueInspections.FindAsync(id);

            if (venueInspection == null)
            {
                return NotFound();
            }

            return venueInspection;
        }

        // PUT: api/VenueInspections/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVenueInspection(int id, VenueInspection venueInspection)
        {
            if (id != venueInspection.VenueInspectionId)
            {
                return BadRequest();
            }

            _context.Entry(venueInspection).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VenueInspectionExists(id))
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

        // POST: api/VenueInspections
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VenueInspection>> PostVenueInspection(VenueInspection venueInspection)
        {
          if (_context.VenueInspections == null)
          {
              return Problem("Entity set 'Platinum_Island_DatabaseContext.VenueInspections'  is null.");
          }
            _context.VenueInspections.Add(venueInspection);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVenueInspection", new { id = venueInspection.VenueInspectionId }, venueInspection);
        }

        // DELETE: api/VenueInspections/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVenueInspection(int id)
        {
            if (_context.VenueInspections == null)
            {
                return NotFound();
            }
            var venueInspection = await _context.VenueInspections.FindAsync(id);
            if (venueInspection == null)
            {
                return NotFound();
            }

            _context.VenueInspections.Remove(venueInspection);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VenueInspectionExists(int id)
        {
            return (_context.VenueInspections?.Any(e => e.VenueInspectionId == id)).GetValueOrDefault();
        }
    }
}
