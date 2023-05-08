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
    public class RoomPaymentsController : ControllerBase
    {
        private readonly Platinum_Island_DatabaseContext _context;

        public RoomPaymentsController(Platinum_Island_DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/RoomPayments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomPayment>>> GetRoomPayments()
        {
          if (_context.RoomPayments == null)
          {
              return NotFound();
          }
            return await _context.RoomPayments.ToListAsync();
        }

        // GET: api/RoomPayments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomPayment>> GetRoomPayment(int id)
        {
          if (_context.RoomPayments == null)
          {
              return NotFound();
          }
            var roomPayment = await _context.RoomPayments.FindAsync(id);

            if (roomPayment == null)
            {
                return NotFound();
            }

            return roomPayment;
        }

        // PUT: api/RoomPayments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomPayment(int id, RoomPayment roomPayment)
        {
            if (id != roomPayment.RoomPaymentId)
            {
                return BadRequest();
            }

            _context.Entry(roomPayment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomPaymentExists(id))
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

        // POST: api/RoomPayments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RoomPayment>> PostRoomPayment(RoomPayment roomPayment)
        {
          if (_context.RoomPayments == null)
          {
              return Problem("Entity set 'Platinum_Island_DatabaseContext.RoomPayments'  is null.");
          }
            _context.RoomPayments.Add(roomPayment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoomPayment", new { id = roomPayment.RoomPaymentId }, roomPayment);
        }

        // DELETE: api/RoomPayments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomPayment(int id)
        {
            if (_context.RoomPayments == null)
            {
                return NotFound();
            }
            var roomPayment = await _context.RoomPayments.FindAsync(id);
            if (roomPayment == null)
            {
                return NotFound();
            }

            _context.RoomPayments.Remove(roomPayment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoomPaymentExists(int id)
        {
            return (_context.RoomPayments?.Any(e => e.RoomPaymentId == id)).GetValueOrDefault();
        }
    }
}
