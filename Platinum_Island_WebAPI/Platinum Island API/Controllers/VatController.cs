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
    public class VatController : ControllerBase
    {
        private readonly Platinum_Island_DatabaseContext _context;

        public VatController(Platinum_Island_DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Vat
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vat>>> GetVats()
        {
          if (_context.Vats == null)
          {
              return NotFound();
          }
            return await _context.Vats.ToListAsync();
        }

        // GET: api/Vat/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vat>> GetVat(int id)
        {
          if (_context.Vats == null)
          {
              return NotFound();
          }
            var vat = await _context.Vats.FindAsync(id);

            if (vat == null)
            {
                return NotFound();
            }

            return vat;
        }

        // PUT: api/Vat/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVat(int id, Vat vat)
        {
            if (id != vat.VatId)
            {
                return BadRequest();
            }

            _context.Entry(vat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VatExists(id))
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

        // POST: api/Vat
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vat>> PostVat(Vat vat)
        {
          if (_context.Vats == null)
          {
              return Problem("Entity set 'Platinum_Island_DatabaseContext.Vats'  is null.");
          }
            _context.Vats.Add(vat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVat", new { id = vat.VatId }, vat);
        }

        // DELETE: api/Vat/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVat(int id)
        {
            if (_context.Vats == null)
            {
                return NotFound();
            }
            var vat = await _context.Vats.FindAsync(id);
            if (vat == null)
            {
                return NotFound();
            }

            _context.Vats.Remove(vat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VatExists(int id)
        {
            return (_context.Vats?.Any(e => e.VatId == id)).GetValueOrDefault();
        }
    }
}
