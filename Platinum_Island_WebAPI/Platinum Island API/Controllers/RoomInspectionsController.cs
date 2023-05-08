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
    public class RoomInspectionsController : ControllerBase
    {
        private readonly Platinum_Island_DatabaseContext _context;

        public RoomInspectionsController(Platinum_Island_DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/RoomInspections
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomInspection>>> GetRoomInspections()
        {
          if (_context.RoomInspections == null)
          {
              return NotFound();
          }
            return await _context.RoomInspections.ToListAsync();
        }

        // GET: api/RoomInspections/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomInspection>> GetRoomInspection(int id)
        {
          if (_context.RoomInspections == null)
          {
              return NotFound();
          }
            var roomInspection = await _context.RoomInspections.FindAsync(id);

            if (roomInspection == null)
            {
                return NotFound();
            }

            return roomInspection;
        }

        // PUT: api/RoomInspections/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomInspection(int id, RoomInspection roomInspection)
        {
            if (id != roomInspection.RoomInspectionId)
            {
                return BadRequest();
            }

            _context.Entry(roomInspection).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomInspectionExists(id))
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

        // POST: api/RoomInspections
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RoomInspection>> PostRoomInspection(RoomInspection roomInspection)
        {
          if (_context.RoomInspections == null)
          {
              return Problem("Entity set 'Platinum_Island_DatabaseContext.RoomInspections'  is null.");
          }
            _context.RoomInspections.Add(roomInspection);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoomInspection", new { id = roomInspection.RoomInspectionId }, roomInspection);
        }

        // DELETE: api/RoomInspections/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomInspection(int id)
        {
            if (_context.RoomInspections == null)
            {
                return NotFound();
            }
            var roomInspection = await _context.RoomInspections.FindAsync(id);
            if (roomInspection == null)
            {
                return NotFound();
            }

            _context.RoomInspections.Remove(roomInspection);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoomInspectionExists(int id)
        {
            return (_context.RoomInspections?.Any(e => e.RoomInspectionId == id)).GetValueOrDefault();
        }
    }
}
