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
    public class SupplierOrdersController : ControllerBase
    {
        private readonly Platinum_Island_DatabaseContext _context;

        public SupplierOrdersController(Platinum_Island_DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/SupplierOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupplierOrder>>> GetSupplierOrders()
        {
          if (_context.SupplierOrders == null)
          {
              return NotFound();
          }
            return await _context.SupplierOrders.ToListAsync();
        }

        // GET: api/SupplierOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SupplierOrder>> GetSupplierOrder(int id)
        {
          if (_context.SupplierOrders == null)
          {
              return NotFound();
          }
            var supplierOrder = await _context.SupplierOrders.FindAsync(id);

            if (supplierOrder == null)
            {
                return NotFound();
            }

            return supplierOrder;
        }

        // PUT: api/SupplierOrders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupplierOrder(int id, SupplierOrder supplierOrder)
        {
            if (id != supplierOrder.OrderId)
            {
                return BadRequest();
            }

            _context.Entry(supplierOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupplierOrderExists(id))
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

        // POST: api/SupplierOrders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SupplierOrder>> PostSupplierOrder(SupplierOrder supplierOrder)
        {
          if (_context.SupplierOrders == null)
          {
              return Problem("Entity set 'Platinum_Island_DatabaseContext.SupplierOrders'  is null.");
          }
            _context.SupplierOrders.Add(supplierOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSupplierOrder", new { id = supplierOrder.OrderId }, supplierOrder);
        }

        // DELETE: api/SupplierOrders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupplierOrder(int id)
        {
            if (_context.SupplierOrders == null)
            {
                return NotFound();
            }
            var supplierOrder = await _context.SupplierOrders.FindAsync(id);
            if (supplierOrder == null)
            {
                return NotFound();
            }

            _context.SupplierOrders.Remove(supplierOrder);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SupplierOrderExists(int id)
        {
            return (_context.SupplierOrders?.Any(e => e.OrderId == id)).GetValueOrDefault();
        }
    }
}
