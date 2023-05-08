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
    public class DayVisitRefundsController : ControllerBase
    {
        private readonly Platinum_Island_DatabaseContext _context;

        public DayVisitRefundsController(Platinum_Island_DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/DayVisitRefunds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DayVisitRefund>>> GetDayVisitRefunds()
        {
          if (_context.DayVisitRefunds == null)
          {
              return NotFound();
          }
            return await _context.DayVisitRefunds.ToListAsync();
        }

        // GET: api/DayVisitRefunds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DayVisitRefund>> GetDayVisitRefund(int id)
        {
          if (_context.DayVisitRefunds == null)
          {
              return NotFound();
          }
            var dayVisitRefund = await _context.DayVisitRefunds.FindAsync(id);

            if (dayVisitRefund == null)
            {
                return NotFound();
            }

            return dayVisitRefund;
        }

        // PUT: api/DayVisitRefunds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDayVisitRefund(int id, DayVisitRefund dayVisitRefund)
        {
            if (id != dayVisitRefund.RefundId)
            {
                return BadRequest();
            }

            _context.Entry(dayVisitRefund).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DayVisitRefundExists(id))
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

        // POST: api/DayVisitRefunds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DayVisitRefund>> PostDayVisitRefund(DayVisitRefund dayVisitRefund)
        {
          if (_context.DayVisitRefunds == null)
          {
              return Problem("Entity set 'Platinum_Island_DatabaseContext.DayVisitRefunds'  is null.");
          }
            _context.DayVisitRefunds.Add(dayVisitRefund);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDayVisitRefund", new { id = dayVisitRefund.RefundId }, dayVisitRefund);
        }

        // DELETE: api/DayVisitRefunds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDayVisitRefund(int id)
        {
            if (_context.DayVisitRefunds == null)
            {
                return NotFound();
            }
            var dayVisitRefund = await _context.DayVisitRefunds.FindAsync(id);
            if (dayVisitRefund == null)
            {
                return NotFound();
            }

            _context.DayVisitRefunds.Remove(dayVisitRefund);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DayVisitRefundExists(int id)
        {
            return (_context.DayVisitRefunds?.Any(e => e.RefundId == id)).GetValueOrDefault();
        }
    }
}
