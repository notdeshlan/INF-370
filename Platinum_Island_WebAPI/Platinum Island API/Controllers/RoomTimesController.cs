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
    public class RoomTimesController : ControllerBase
    {
        private readonly Platinum_Island_DatabaseContext _context;

        public RoomTimesController(Platinum_Island_DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/RoomTimes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomTime>>> GetRoomTimes()
        {
          if (_context.RoomTimes == null)
          {
              return NotFound();
          }
            return await _context.RoomTimes.ToListAsync();
        }

        // GET: api/RoomTimes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomTime>> GetRoomTime(int id)
        {
          if (_context.RoomTimes == null)
          {
              return NotFound();
          }
            var roomTime = await _context.RoomTimes.FindAsync(id);

            if (roomTime == null)
            {
                return NotFound();
            }

            return roomTime;
        }

        // PUT: api/RoomTimes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomTime(int id, RoomTime roomTime)
        {
            if (id != roomTime.RoomTimeId)
            {
                return BadRequest();
            }

            _context.Entry(roomTime).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomTimeExists(id))
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

        // POST: api/RoomTimes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RoomTime>> PostRoomTime(RoomTime roomTime)
        {
          if (_context.RoomTimes == null)
          {
              return Problem("Entity set 'Platinum_Island_DatabaseContext.RoomTimes'  is null.");
          }
            _context.RoomTimes.Add(roomTime);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoomTime", new { id = roomTime.RoomTimeId }, roomTime);
        }

        // DELETE: api/RoomTimes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomTime(int id)
        {
            if (_context.RoomTimes == null)
            {
                return NotFound();
            }
            var roomTime = await _context.RoomTimes.FindAsync(id);
            if (roomTime == null)
            {
                return NotFound();
            }

            _context.RoomTimes.Remove(roomTime);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoomTimeExists(int id)
        {
            return (_context.RoomTimes?.Any(e => e.RoomTimeId == id)).GetValueOrDefault();
        }
    }
}
