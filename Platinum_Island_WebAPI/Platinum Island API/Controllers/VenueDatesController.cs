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
    public class VenueDatesController : ControllerBase
    {
        private readonly Platinum_Island_DatabaseContext _context;

        public VenueDatesController(Platinum_Island_DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/VenueDates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VenueDate>>> GetVenueDates()
        {
          if (_context.VenueDates == null)
          {
              return NotFound();
          }
            return await _context.VenueDates.ToListAsync();
        }

        // GET: api/VenueDates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VenueDate>> GetVenueDate(int id)
        {
          if (_context.VenueDates == null)
          {
              return NotFound();
          }
            var venueDate = await _context.VenueDates.FindAsync(id);

            if (venueDate == null)
            {
                return NotFound();
            }

            return venueDate;
        }

        // PUT: api/VenueDates/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVenueDate(int id, VenueDate venueDate)
        {
            if (id != venueDate.VenueDateId)
            {
                return BadRequest();
            }

            _context.Entry(venueDate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VenueDateExists(id))
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

        // POST: api/VenueDates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VenueDate>> PostVenueDate(VenueDate venueDate)
        {
          if (_context.VenueDates == null)
          {
              return Problem("Entity set 'Platinum_Island_DatabaseContext.VenueDates'  is null.");
          }
            _context.VenueDates.Add(venueDate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVenueDate", new { id = venueDate.VenueDateId }, venueDate);
        }

        // DELETE: api/VenueDates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVenueDate(int id)
        {
            if (_context.VenueDates == null)
            {
                return NotFound();
            }
            var venueDate = await _context.VenueDates.FindAsync(id);
            if (venueDate == null)
            {
                return NotFound();
            }

            _context.VenueDates.Remove(venueDate);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VenueDateExists(int id)
        {
            return (_context.VenueDates?.Any(e => e.VenueDateId == id)).GetValueOrDefault();
        }
    }
}
