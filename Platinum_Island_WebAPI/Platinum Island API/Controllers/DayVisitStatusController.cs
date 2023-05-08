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
    public class DayVisitStatusController : ControllerBase
    {
        private readonly Platinum_Island_DatabaseContext _context;

        public DayVisitStatusController(Platinum_Island_DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/DayVisitStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DayVisitStatus>>> GetDayVisitStatuses()
        {
          if (_context.DayVisitStatuses == null)
          {
              return NotFound();
          }
            return await _context.DayVisitStatuses.ToListAsync();
        }

        // GET: api/DayVisitStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DayVisitStatus>> GetDayVisitStatus(int id)
        {
          if (_context.DayVisitStatuses == null)
          {
              return NotFound();
          }
            var dayVisitStatus = await _context.DayVisitStatuses.FindAsync(id);

            if (dayVisitStatus == null)
            {
                return NotFound();
            }

            return dayVisitStatus;
        }

        // PUT: api/DayVisitStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDayVisitStatus(int id, DayVisitStatus dayVisitStatus)
        {
            if (id != dayVisitStatus.DayVisitStatusId)
            {
                return BadRequest();
            }

            _context.Entry(dayVisitStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DayVisitStatusExists(id))
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

        // POST: api/DayVisitStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DayVisitStatus>> PostDayVisitStatus(DayVisitStatus dayVisitStatus)
        {
          if (_context.DayVisitStatuses == null)
          {
              return Problem("Entity set 'Platinum_Island_DatabaseContext.DayVisitStatuses'  is null.");
          }
            _context.DayVisitStatuses.Add(dayVisitStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDayVisitStatus", new { id = dayVisitStatus.DayVisitStatusId }, dayVisitStatus);
        }

        // DELETE: api/DayVisitStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDayVisitStatus(int id)
        {
            if (_context.DayVisitStatuses == null)
            {
                return NotFound();
            }
            var dayVisitStatus = await _context.DayVisitStatuses.FindAsync(id);
            if (dayVisitStatus == null)
            {
                return NotFound();
            }

            _context.DayVisitStatuses.Remove(dayVisitStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DayVisitStatusExists(int id)
        {
            return (_context.DayVisitStatuses?.Any(e => e.DayVisitStatusId == id)).GetValueOrDefault();
        }
    }
}
