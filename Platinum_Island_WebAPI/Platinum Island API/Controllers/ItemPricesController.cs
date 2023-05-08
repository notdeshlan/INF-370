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
    public class ItemPricesController : ControllerBase
    {
        private readonly Platinum_Island_DatabaseContext _context;

        public ItemPricesController(Platinum_Island_DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/ItemPrices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemPrice>>> GetItemPrices()
        {
          if (_context.ItemPrices == null)
          {
              return NotFound();
          }
            return await _context.ItemPrices.ToListAsync();
        }

        // GET: api/ItemPrices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemPrice>> GetItemPrice(int id)
        {
          if (_context.ItemPrices == null)
          {
              return NotFound();
          }
            var itemPrice = await _context.ItemPrices.FindAsync(id);

            if (itemPrice == null)
            {
                return NotFound();
            }

            return itemPrice;
        }

        // PUT: api/ItemPrices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemPrice(int id, ItemPrice itemPrice)
        {
            if (id != itemPrice.ItemPriceId)
            {
                return BadRequest();
            }

            _context.Entry(itemPrice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemPriceExists(id))
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

        // POST: api/ItemPrices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ItemPrice>> PostItemPrice(ItemPrice itemPrice)
        {
          if (_context.ItemPrices == null)
          {
              return Problem("Entity set 'Platinum_Island_DatabaseContext.ItemPrices'  is null.");
          }
            _context.ItemPrices.Add(itemPrice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItemPrice", new { id = itemPrice.ItemPriceId }, itemPrice);
        }

        // DELETE: api/ItemPrices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemPrice(int id)
        {
            if (_context.ItemPrices == null)
            {
                return NotFound();
            }
            var itemPrice = await _context.ItemPrices.FindAsync(id);
            if (itemPrice == null)
            {
                return NotFound();
            }

            _context.ItemPrices.Remove(itemPrice);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemPriceExists(int id)
        {
            return (_context.ItemPrices?.Any(e => e.ItemPriceId == id)).GetValueOrDefault();
        }
    }
}
