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
    public class RoomStatusController : ControllerBase
    {
        private readonly Platinum_Island_DatabaseContext _context;

        public RoomStatusController(Platinum_Island_DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/RoomStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomStatus>>> GetRoomStatuses()
        {
          if (_context.RoomStatuses == null)
          {
              return NotFound();
          }
            return await _context.RoomStatuses.ToListAsync();
        }

        // GET: api/RoomStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomStatus>> GetRoomStatus(int id)
        {
          if (_context.RoomStatuses == null)
          {
              return NotFound();
          }
            var roomStatus = await _context.RoomStatuses.FindAsync(id);

            if (roomStatus == null)
            {
                return NotFound();
            }

            return roomStatus;
        }

        // PUT: api/RoomStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomStatus(int id, RoomStatus roomStatus)
        {
            if (id != roomStatus.RoomStatusId)
            {
                return BadRequest();
            }

            _context.Entry(roomStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomStatusExists(id))
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

        // POST: api/RoomStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RoomStatus>> PostRoomStatus(RoomStatus roomStatus)
        {
          if (_context.RoomStatuses == null)
          {
              return Problem("Entity set 'Platinum_Island_DatabaseContext.RoomStatuses'  is null.");
          }
            _context.RoomStatuses.Add(roomStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoomStatus", new { id = roomStatus.RoomStatusId }, roomStatus);
        }

        // DELETE: api/RoomStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomStatus(int id)
        {
            if (_context.RoomStatuses == null)
            {
                return NotFound();
            }
            var roomStatus = await _context.RoomStatuses.FindAsync(id);
            if (roomStatus == null)
            {
                return NotFound();
            }

            _context.RoomStatuses.Remove(roomStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoomStatusExists(int id)
        {
            return (_context.RoomStatuses?.Any(e => e.RoomStatusId == id)).GetValueOrDefault();
        }
    }
}
