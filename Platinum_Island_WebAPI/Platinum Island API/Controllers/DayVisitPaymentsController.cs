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
    public class DayVisitPaymentsController : ControllerBase
    {
        private readonly Platinum_Island_DatabaseContext _context;

        public DayVisitPaymentsController(Platinum_Island_DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/DayVisitPayments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DayVisitPayment>>> GetDayVisitPayments()
        {
          if (_context.DayVisitPayments == null)
          {
              return NotFound();
          }
            return await _context.DayVisitPayments.ToListAsync();
        }

        // GET: api/DayVisitPayments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DayVisitPayment>> GetDayVisitPayment(int id)
        {
          if (_context.DayVisitPayments == null)
          {
              return NotFound();
          }
            var dayVisitPayment = await _context.DayVisitPayments.FindAsync(id);

            if (dayVisitPayment == null)
            {
                return NotFound();
            }

            return dayVisitPayment;
        }

        // PUT: api/DayVisitPayments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDayVisitPayment(int id, DayVisitPayment dayVisitPayment)
        {
            if (id != dayVisitPayment.DayVisitPaymentId)
            {
                return BadRequest();
            }

            _context.Entry(dayVisitPayment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DayVisitPaymentExists(id))
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

        // POST: api/DayVisitPayments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DayVisitPayment>> PostDayVisitPayment(DayVisitPayment dayVisitPayment)
        {
          if (_context.DayVisitPayments == null)
          {
              return Problem("Entity set 'Platinum_Island_DatabaseContext.DayVisitPayments'  is null.");
          }
            _context.DayVisitPayments.Add(dayVisitPayment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDayVisitPayment", new { id = dayVisitPayment.DayVisitPaymentId }, dayVisitPayment);
        }

        // DELETE: api/DayVisitPayments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDayVisitPayment(int id)
        {
            if (_context.DayVisitPayments == null)
            {
                return NotFound();
            }
            var dayVisitPayment = await _context.DayVisitPayments.FindAsync(id);
            if (dayVisitPayment == null)
            {
                return NotFound();
            }

            _context.DayVisitPayments.Remove(dayVisitPayment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DayVisitPaymentExists(int id)
        {
            return (_context.DayVisitPayments?.Any(e => e.DayVisitPaymentId == id)).GetValueOrDefault();
        }
    }
}
