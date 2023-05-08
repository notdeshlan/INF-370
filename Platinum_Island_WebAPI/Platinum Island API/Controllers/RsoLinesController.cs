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
    public class RsoLinesController : ControllerBase
    {
        private readonly Platinum_Island_DatabaseContext _context;

        public RsoLinesController(Platinum_Island_DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/RsoLines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RsoLine>>> GetRsoLines()
        {
          if (_context.RsoLines == null)
          {
              return NotFound();
          }
            return await _context.RsoLines.ToListAsync();
        }

        // GET: api/RsoLines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RsoLine>> GetRsoLine(int id)
        {
          if (_context.RsoLines == null)
          {
              return NotFound();
          }
            var rsoLine = await _context.RsoLines.FindAsync(id);

            if (rsoLine == null)
            {
                return NotFound();
            }

            return rsoLine;
        }

        // PUT: api/RsoLines/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRsoLine(int id, RsoLine rsoLine)
        {
            if (id != rsoLine.Rsoid)
            {
                return BadRequest();
            }

            _context.Entry(rsoLine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RsoLineExists(id))
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

        // POST: api/RsoLines
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RsoLine>> PostRsoLine(RsoLine rsoLine)
        {
          if (_context.RsoLines == null)
          {
              return Problem("Entity set 'Platinum_Island_DatabaseContext.RsoLines'  is null.");
          }
            _context.RsoLines.Add(rsoLine);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RsoLineExists(rsoLine.Rsoid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRsoLine", new { id = rsoLine.Rsoid }, rsoLine);
        }

        // DELETE: api/RsoLines/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRsoLine(int id)
        {
            if (_context.RsoLines == null)
            {
                return NotFound();
            }
            var rsoLine = await _context.RsoLines.FindAsync(id);
            if (rsoLine == null)
            {
                return NotFound();
            }

            _context.RsoLines.Remove(rsoLine);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RsoLineExists(int id)
        {
            return (_context.RsoLines?.Any(e => e.Rsoid == id)).GetValueOrDefault();
        }
    }
}
