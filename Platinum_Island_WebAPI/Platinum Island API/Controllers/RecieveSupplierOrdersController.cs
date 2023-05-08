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
    public class RecieveSupplierOrdersController : ControllerBase
    {
        private readonly Platinum_Island_DatabaseContext _context;

        public RecieveSupplierOrdersController(Platinum_Island_DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/RecieveSupplierOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecieveSupplierOrder>>> GetRecieveSupplierOrders()
        {
          if (_context.RecieveSupplierOrders == null)
          {
              return NotFound();
          }
            return await _context.RecieveSupplierOrders.ToListAsync();
        }

        // GET: api/RecieveSupplierOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RecieveSupplierOrder>> GetRecieveSupplierOrder(int id)
        {
          if (_context.RecieveSupplierOrders == null)
          {
              return NotFound();
          }
            var recieveSupplierOrder = await _context.RecieveSupplierOrders.FindAsync(id);

            if (recieveSupplierOrder == null)
            {
                return NotFound();
            }

            return recieveSupplierOrder;
        }

        // PUT: api/RecieveSupplierOrders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecieveSupplierOrder(int id, RecieveSupplierOrder recieveSupplierOrder)
        {
            if (id != recieveSupplierOrder.RsoId)
            {
                return BadRequest();
            }

            _context.Entry(recieveSupplierOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecieveSupplierOrderExists(id))
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

        // POST: api/RecieveSupplierOrders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RecieveSupplierOrder>> PostRecieveSupplierOrder(RecieveSupplierOrder recieveSupplierOrder)
        {
          if (_context.RecieveSupplierOrders == null)
          {
              return Problem("Entity set 'Platinum_Island_DatabaseContext.RecieveSupplierOrders'  is null.");
          }
            _context.RecieveSupplierOrders.Add(recieveSupplierOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecieveSupplierOrder", new { id = recieveSupplierOrder.RsoId }, recieveSupplierOrder);
        }

        // DELETE: api/RecieveSupplierOrders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecieveSupplierOrder(int id)
        {
            if (_context.RecieveSupplierOrders == null)
            {
                return NotFound();
            }
            var recieveSupplierOrder = await _context.RecieveSupplierOrders.FindAsync(id);
            if (recieveSupplierOrder == null)
            {
                return NotFound();
            }

            _context.RecieveSupplierOrders.Remove(recieveSupplierOrder);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecieveSupplierOrderExists(int id)
        {
            return (_context.RecieveSupplierOrders?.Any(e => e.RsoId == id)).GetValueOrDefault();
        }
    }
}
