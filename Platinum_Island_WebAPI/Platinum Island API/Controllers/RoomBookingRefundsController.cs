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
    public class RoomBookingRefundsController : ControllerBase
    {
        private readonly Platinum_Island_DatabaseContext _context;

        public RoomBookingRefundsController(Platinum_Island_DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/RoomBookingRefunds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomBookingRefund>>> GetRoomBookingRefunds()
        {
          if (_context.RoomBookingRefunds == null)
          {
              return NotFound();
          }
            return await _context.RoomBookingRefunds.ToListAsync();
        }

        // GET: api/RoomBookingRefunds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomBookingRefund>> GetRoomBookingRefund(int id)
        {
          if (_context.RoomBookingRefunds == null)
          {
              return NotFound();
          }
            var roomBookingRefund = await _context.RoomBookingRefunds.FindAsync(id);

            if (roomBookingRefund == null)
            {
                return NotFound();
            }

            return roomBookingRefund;
        }

        // PUT: api/RoomBookingRefunds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomBookingRefund(int id, RoomBookingRefund roomBookingRefund)
        {
            if (id != roomBookingRefund.RefundId)
            {
                return BadRequest();
            }

            _context.Entry(roomBookingRefund).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomBookingRefundExists(id))
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

        // POST: api/RoomBookingRefunds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RoomBookingRefund>> PostRoomBookingRefund(RoomBookingRefund roomBookingRefund)
        {
          if (_context.RoomBookingRefunds == null)
          {
              return Problem("Entity set 'Platinum_Island_DatabaseContext.RoomBookingRefunds'  is null.");
          }
            _context.RoomBookingRefunds.Add(roomBookingRefund);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoomBookingRefund", new { id = roomBookingRefund.RefundId }, roomBookingRefund);
        }

        // DELETE: api/RoomBookingRefunds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomBookingRefund(int id)
        {
            if (_context.RoomBookingRefunds == null)
            {
                return NotFound();
            }
            var roomBookingRefund = await _context.RoomBookingRefunds.FindAsync(id);
            if (roomBookingRefund == null)
            {
                return NotFound();
            }

            _context.RoomBookingRefunds.Remove(roomBookingRefund);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoomBookingRefundExists(int id)
        {
            return (_context.RoomBookingRefunds?.Any(e => e.RefundId == id)).GetValueOrDefault();
        }
    }
}
