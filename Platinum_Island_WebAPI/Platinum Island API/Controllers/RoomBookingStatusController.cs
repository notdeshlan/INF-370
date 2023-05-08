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
    public class RoomBookingStatusController : ControllerBase
    {
        private readonly Platinum_Island_DatabaseContext _context;

        public RoomBookingStatusController(Platinum_Island_DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/RoomBookingStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomBookingStatus>>> GetRoomBookingStatuses()
        {
          if (_context.RoomBookingStatuses == null)
          {
              return NotFound();
          }
            return await _context.RoomBookingStatuses.ToListAsync();
        }

        // GET: api/RoomBookingStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomBookingStatus>> GetRoomBookingStatus(int id)
        {
          if (_context.RoomBookingStatuses == null)
          {
              return NotFound();
          }
            var roomBookingStatus = await _context.RoomBookingStatuses.FindAsync(id);

            if (roomBookingStatus == null)
            {
                return NotFound();
            }

            return roomBookingStatus;
        }

        // PUT: api/RoomBookingStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomBookingStatus(int id, RoomBookingStatus roomBookingStatus)
        {
            if (id != roomBookingStatus.RoomBookingStatusId)
            {
                return BadRequest();
            }

            _context.Entry(roomBookingStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomBookingStatusExists(id))
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

        // POST: api/RoomBookingStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RoomBookingStatus>> PostRoomBookingStatus(RoomBookingStatus roomBookingStatus)
        {
          if (_context.RoomBookingStatuses == null)
          {
              return Problem("Entity set 'Platinum_Island_DatabaseContext.RoomBookingStatuses'  is null.");
          }
            _context.RoomBookingStatuses.Add(roomBookingStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoomBookingStatus", new { id = roomBookingStatus.RoomBookingStatusId }, roomBookingStatus);
        }

        // DELETE: api/RoomBookingStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomBookingStatus(int id)
        {
            if (_context.RoomBookingStatuses == null)
            {
                return NotFound();
            }
            var roomBookingStatus = await _context.RoomBookingStatuses.FindAsync(id);
            if (roomBookingStatus == null)
            {
                return NotFound();
            }

            _context.RoomBookingStatuses.Remove(roomBookingStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoomBookingStatusExists(int id)
        {
            return (_context.RoomBookingStatuses?.Any(e => e.RoomBookingStatusId == id)).GetValueOrDefault();
        }
    }
}
