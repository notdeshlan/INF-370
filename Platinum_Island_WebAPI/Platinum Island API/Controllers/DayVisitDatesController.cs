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
    public class DayVisitDatesController : ControllerBase
    {
        private readonly Platinum_Island_DatabaseContext _context;

        public DayVisitDatesController(Platinum_Island_DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/DayVisitDates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DayVisitDate>>> GetDayVisitDates()
        {
          if (_context.DayVisitDates == null)
          {
              return NotFound();
          }
            return await _context.DayVisitDates.ToListAsync();
        }

        // GET: api/DayVisitDates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DayVisitDate>> GetDayVisitDate(int id)
        {
          if (_context.DayVisitDates == null)
          {
              return NotFound();
          }
            var dayVisitDate = await _context.DayVisitDates.FindAsync(id);

            if (dayVisitDate == null)
            {
                return NotFound();
            }

            return dayVisitDate;
        }

        // PUT: api/DayVisitDates/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDayVisitDate(int id, DayVisitDate dayVisitDate)
        {
            if (id != dayVisitDate.DayVisitDateId)
            {
                return BadRequest();
            }

            _context.Entry(dayVisitDate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DayVisitDateExists(id))
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

        // POST: api/DayVisitDates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DayVisitDate>> PostDayVisitDate(DayVisitDate dayVisitDate)
        {
          if (_context.DayVisitDates == null)
          {
              return Problem("Entity set 'Platinum_Island_DatabaseContext.DayVisitDates'  is null.");
          }
            _context.DayVisitDates.Add(dayVisitDate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDayVisitDate", new { id = dayVisitDate.DayVisitDateId }, dayVisitDate);
        }

        // DELETE: api/DayVisitDates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDayVisitDate(int id)
        {
            if (_context.DayVisitDates == null)
            {
                return NotFound();
            }
            var dayVisitDate = await _context.DayVisitDates.FindAsync(id);
            if (dayVisitDate == null)
            {
                return NotFound();
            }

            _context.DayVisitDates.Remove(dayVisitDate);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DayVisitDateExists(int id)
        {
            return (_context.DayVisitDates?.Any(e => e.DayVisitDateId == id)).GetValueOrDefault();
        }
    }
}
