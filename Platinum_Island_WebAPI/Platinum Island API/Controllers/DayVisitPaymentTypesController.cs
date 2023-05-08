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
    public class DayVisitPaymentTypesController : ControllerBase
    {
        private readonly Platinum_Island_DatabaseContext _context;

        public DayVisitPaymentTypesController(Platinum_Island_DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/DayVisitPaymentTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DayVisitPaymentType>>> GetDayVisitPaymentTypes()
        {
          if (_context.DayVisitPaymentTypes == null)
          {
              return NotFound();
          }
            return await _context.DayVisitPaymentTypes.ToListAsync();
        }

        // GET: api/DayVisitPaymentTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DayVisitPaymentType>> GetDayVisitPaymentType(int id)
        {
          if (_context.DayVisitPaymentTypes == null)
          {
              return NotFound();
          }
            var dayVisitPaymentType = await _context.DayVisitPaymentTypes.FindAsync(id);

            if (dayVisitPaymentType == null)
            {
                return NotFound();
            }

            return dayVisitPaymentType;
        }

        // PUT: api/DayVisitPaymentTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDayVisitPaymentType(int id, DayVisitPaymentType dayVisitPaymentType)
        {
            if (id != dayVisitPaymentType.PaymentTypeId)
            {
                return BadRequest();
            }

            _context.Entry(dayVisitPaymentType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DayVisitPaymentTypeExists(id))
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

        // POST: api/DayVisitPaymentTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DayVisitPaymentType>> PostDayVisitPaymentType(DayVisitPaymentType dayVisitPaymentType)
        {
          if (_context.DayVisitPaymentTypes == null)
          {
              return Problem("Entity set 'Platinum_Island_DatabaseContext.DayVisitPaymentTypes'  is null.");
          }
            _context.DayVisitPaymentTypes.Add(dayVisitPaymentType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDayVisitPaymentType", new { id = dayVisitPaymentType.PaymentTypeId }, dayVisitPaymentType);
        }

        // DELETE: api/DayVisitPaymentTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDayVisitPaymentType(int id)
        {
            if (_context.DayVisitPaymentTypes == null)
            {
                return NotFound();
            }
            var dayVisitPaymentType = await _context.DayVisitPaymentTypes.FindAsync(id);
            if (dayVisitPaymentType == null)
            {
                return NotFound();
            }

            _context.DayVisitPaymentTypes.Remove(dayVisitPaymentType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DayVisitPaymentTypeExists(int id)
        {
            return (_context.DayVisitPaymentTypes?.Any(e => e.PaymentTypeId == id)).GetValueOrDefault();
        }
    }
}
