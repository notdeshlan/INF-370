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
    public class RoomInspectionWriteOffsController : ControllerBase
    {
        private readonly Platinum_Island_DatabaseContext _context;

        public RoomInspectionWriteOffsController(Platinum_Island_DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/RoomInspectionWriteOffs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomInspectionWriteOff>>> GetRoomInspectionWriteOffs()
        {
          if (_context.RoomInspectionWriteOffs == null)
          {
              return NotFound();
          }
            return await _context.RoomInspectionWriteOffs.ToListAsync();
        }

        // GET: api/RoomInspectionWriteOffs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomInspectionWriteOff>> GetRoomInspectionWriteOff(int id)
        {
          if (_context.RoomInspectionWriteOffs == null)
          {
              return NotFound();
          }
            var roomInspectionWriteOff = await _context.RoomInspectionWriteOffs.FindAsync(id);

            if (roomInspectionWriteOff == null)
            {
                return NotFound();
            }

            return roomInspectionWriteOff;
        }

        // PUT: api/RoomInspectionWriteOffs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomInspectionWriteOff(int id, RoomInspectionWriteOff roomInspectionWriteOff)
        {
            if (id != roomInspectionWriteOff.ItemId)
            {
                return BadRequest();
            }

            _context.Entry(roomInspectionWriteOff).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomInspectionWriteOffExists(id))
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

        // POST: api/RoomInspectionWriteOffs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RoomInspectionWriteOff>> PostRoomInspectionWriteOff(RoomInspectionWriteOff roomInspectionWriteOff)
        {
          if (_context.RoomInspectionWriteOffs == null)
          {
              return Problem("Entity set 'Platinum_Island_DatabaseContext.RoomInspectionWriteOffs'  is null.");
          }
            _context.RoomInspectionWriteOffs.Add(roomInspectionWriteOff);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RoomInspectionWriteOffExists(roomInspectionWriteOff.ItemId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRoomInspectionWriteOff", new { id = roomInspectionWriteOff.ItemId }, roomInspectionWriteOff);
        }

        // DELETE: api/RoomInspectionWriteOffs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomInspectionWriteOff(int id)
        {
            if (_context.RoomInspectionWriteOffs == null)
            {
                return NotFound();
            }
            var roomInspectionWriteOff = await _context.RoomInspectionWriteOffs.FindAsync(id);
            if (roomInspectionWriteOff == null)
            {
                return NotFound();
            }

            _context.RoomInspectionWriteOffs.Remove(roomInspectionWriteOff);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoomInspectionWriteOffExists(int id)
        {
            return (_context.RoomInspectionWriteOffs?.Any(e => e.ItemId == id)).GetValueOrDefault();
        }
    }
}
