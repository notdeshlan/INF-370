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
    public class RoomPaymentTypesController : ControllerBase
    {
        private readonly Platinum_Island_DatabaseContext _context;

        public RoomPaymentTypesController(Platinum_Island_DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/RoomPaymentTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomPaymentType>>> GetRoomPaymentTypes()
        {
          if (_context.RoomPaymentTypes == null)
          {
              return NotFound();
          }
            return await _context.RoomPaymentTypes.ToListAsync();
        }

        // GET: api/RoomPaymentTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomPaymentType>> GetRoomPaymentType(int id)
        {
          if (_context.RoomPaymentTypes == null)
          {
              return NotFound();
          }
            var roomPaymentType = await _context.RoomPaymentTypes.FindAsync(id);

            if (roomPaymentType == null)
            {
                return NotFound();
            }

            return roomPaymentType;
        }

        // PUT: api/RoomPaymentTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomPaymentType(int id, RoomPaymentType roomPaymentType)
        {
            if (id != roomPaymentType.PaymentTypeId)
            {
                return BadRequest();
            }

            _context.Entry(roomPaymentType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomPaymentTypeExists(id))
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

        // POST: api/RoomPaymentTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RoomPaymentType>> PostRoomPaymentType(RoomPaymentType roomPaymentType)
        {
          if (_context.RoomPaymentTypes == null)
          {
              return Problem("Entity set 'Platinum_Island_DatabaseContext.RoomPaymentTypes'  is null.");
          }
            _context.RoomPaymentTypes.Add(roomPaymentType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoomPaymentType", new { id = roomPaymentType.PaymentTypeId }, roomPaymentType);
        }

        // DELETE: api/RoomPaymentTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomPaymentType(int id)
        {
            if (_context.RoomPaymentTypes == null)
            {
                return NotFound();
            }
            var roomPaymentType = await _context.RoomPaymentTypes.FindAsync(id);
            if (roomPaymentType == null)
            {
                return NotFound();
            }

            _context.RoomPaymentTypes.Remove(roomPaymentType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoomPaymentTypeExists(int id)
        {
            return (_context.RoomPaymentTypes?.Any(e => e.PaymentTypeId == id)).GetValueOrDefault();
        }
    }
}
