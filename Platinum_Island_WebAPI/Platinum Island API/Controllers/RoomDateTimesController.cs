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
    public class RoomDateTimesController : ControllerBase
    {
        private readonly Platinum_Island_DatabaseContext _context;

        public RoomDateTimesController(Platinum_Island_DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/RoomDateTimes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomDateTime>>> GetRoomDateTimes()
        {
          if (_context.RoomDateTimes == null)
          {
              return NotFound();
          }
            return await _context.RoomDateTimes.ToListAsync();
        }

        // GET: api/RoomDateTimes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomDateTime>> GetRoomDateTime(int id)
        {
          if (_context.RoomDateTimes == null)
          {
              return NotFound();
          }
            var roomDateTime = await _context.RoomDateTimes.FindAsync(id);

            if (roomDateTime == null)
            {
                return NotFound();
            }

            return roomDateTime;
        }

        // PUT: api/RoomDateTimes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomDateTime(int id, RoomDateTime roomDateTime)
        {
            if (id != roomDateTime.DateId)
            {
                return BadRequest();
            }

            _context.Entry(roomDateTime).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomDateTimeExists(id))
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

        // POST: api/RoomDateTimes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RoomDateTime>> PostRoomDateTime(RoomDateTime roomDateTime)
        {
          if (_context.RoomDateTimes == null)
          {
              return Problem("Entity set 'Platinum_Island_DatabaseContext.RoomDateTimes'  is null.");
          }
            _context.RoomDateTimes.Add(roomDateTime);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RoomDateTimeExists(roomDateTime.DateId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRoomDateTime", new { id = roomDateTime.DateId }, roomDateTime);
        }

        // DELETE: api/RoomDateTimes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomDateTime(int id)
        {
            if (_context.RoomDateTimes == null)
            {
                return NotFound();
            }
            var roomDateTime = await _context.RoomDateTimes.FindAsync(id);
            if (roomDateTime == null)
            {
                return NotFound();
            }

            _context.RoomDateTimes.Remove(roomDateTime);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoomDateTimeExists(int id)
        {
            return (_context.RoomDateTimes?.Any(e => e.DateId == id)).GetValueOrDefault();
        }
    }
}
