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
    public class RoomTypePricesController : ControllerBase
    {
        private readonly Platinum_Island_DatabaseContext _context;

        public RoomTypePricesController(Platinum_Island_DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/RoomTypePrices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomTypePrice>>> GetRoomTypePrices()
        {
          if (_context.RoomTypePrices == null)
          {
              return NotFound();
          }
            return await _context.RoomTypePrices.ToListAsync();
        }

        // GET: api/RoomTypePrices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomTypePrice>> GetRoomTypePrice(int id)
        {
          if (_context.RoomTypePrices == null)
          {
              return NotFound();
          }
            var roomTypePrice = await _context.RoomTypePrices.FindAsync(id);

            if (roomTypePrice == null)
            {
                return NotFound();
            }

            return roomTypePrice;
        }

        // PUT: api/RoomTypePrices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomTypePrice(int id, RoomTypePrice roomTypePrice)
        {
            if (id != roomTypePrice.RoomPriceId)
            {
                return BadRequest();
            }

            _context.Entry(roomTypePrice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomTypePriceExists(id))
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

        // POST: api/RoomTypePrices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RoomTypePrice>> PostRoomTypePrice(RoomTypePrice roomTypePrice)
        {
          if (_context.RoomTypePrices == null)
          {
              return Problem("Entity set 'Platinum_Island_DatabaseContext.RoomTypePrices'  is null.");
          }
            _context.RoomTypePrices.Add(roomTypePrice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoomTypePrice", new { id = roomTypePrice.RoomPriceId }, roomTypePrice);
        }

        // DELETE: api/RoomTypePrices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomTypePrice(int id)
        {
            if (_context.RoomTypePrices == null)
            {
                return NotFound();
            }
            var roomTypePrice = await _context.RoomTypePrices.FindAsync(id);
            if (roomTypePrice == null)
            {
                return NotFound();
            }

            _context.RoomTypePrices.Remove(roomTypePrice);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoomTypePriceExists(int id)
        {
            return (_context.RoomTypePrices?.Any(e => e.RoomPriceId == id)).GetValueOrDefault();
        }
    }
}
