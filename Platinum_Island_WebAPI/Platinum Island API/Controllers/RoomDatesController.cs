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
    public class RoomDatesController : ControllerBase
    {
        private readonly Platinum_Island_DatabaseContext _context;

        public RoomDatesController(Platinum_Island_DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/RoomDates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomDate>>> GetRoomDates()
        {
          if (_context.RoomDates == null)
          {
              return NotFound();
          }
            return await _context.RoomDates.ToListAsync();
        }

        // GET: api/RoomDates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomDate>> GetRoomDate(int id)
        {
          if (_context.RoomDates == null)
          {
              return NotFound();
          }
            var roomDate = await _context.RoomDates.FindAsync(id);

            if (roomDate == null)
            {
                return NotFound();
            }

            return roomDate;
        }

        // PUT: api/RoomDates/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomDate(int id, RoomDate roomDate)
        {
            if (id != roomDate.RoomDateId)
            {
                return BadRequest();
            }

            _context.Entry(roomDate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomDateExists(id))
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

        // POST: api/RoomDates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RoomDate>> PostRoomDate(RoomDate roomDate)
        {
          if (_context.RoomDates == null)
          {
              return Problem("Entity set 'Platinum_Island_DatabaseContext.RoomDates'  is null.");
          }
            _context.RoomDates.Add(roomDate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoomDate", new { id = roomDate.RoomDateId }, roomDate);
        }

        // DELETE: api/RoomDates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomDate(int id)
        {
            if (_context.RoomDates == null)
            {
                return NotFound();
            }
            var roomDate = await _context.RoomDates.FindAsync(id);
            if (roomDate == null)
            {
                return NotFound();
            }

            _context.RoomDates.Remove(roomDate);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoomDateExists(int id)
        {
            return (_context.RoomDates?.Any(e => e.RoomDateId == id)).GetValueOrDefault();
        }
    }
}
