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
    public class DayVisitsController : ControllerBase
    {
        private readonly Platinum_Island_DatabaseContext _context;

        public DayVisitsController(Platinum_Island_DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/DayVisits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DayVisit>>> GetDayVisits()
        {
          if (_context.DayVisits == null)
          {
              return NotFound();
          }
            return await _context.DayVisits.ToListAsync();
        }

        // GET: api/DayVisits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DayVisit>> GetDayVisit(int id)
        {
          if (_context.DayVisits == null)
          {
              return NotFound();
          }
            var dayVisit = await _context.DayVisits.FindAsync(id);

            if (dayVisit == null)
            {
                return NotFound();
            }

            return dayVisit;
        }

        // PUT: api/DayVisits/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDayVisit(int id, DayVisit dayVisit)
        {
            if (id != dayVisit.DayVisitId)
            {
                return BadRequest();
            }

            _context.Entry(dayVisit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DayVisitExists(id))
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

        // POST: api/DayVisits
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DayVisit>> PostDayVisit(DayVisit dayVisit)
        {
          if (_context.DayVisits == null)
          {
              return Problem("Entity set 'Platinum_Island_DatabaseContext.DayVisits'  is null.");
          }
            _context.DayVisits.Add(dayVisit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDayVisit", new { id = dayVisit.DayVisitId }, dayVisit);
        }

        // DELETE: api/DayVisits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDayVisit(int id)
        {
            if (_context.DayVisits == null)
            {
                return NotFound();
            }
            var dayVisit = await _context.DayVisits.FindAsync(id);
            if (dayVisit == null)
            {
                return NotFound();
            }

            _context.DayVisits.Remove(dayVisit);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DayVisitExists(int id)
        {
            return (_context.DayVisits?.Any(e => e.DayVisitId == id)).GetValueOrDefault();
        }
    }
}
