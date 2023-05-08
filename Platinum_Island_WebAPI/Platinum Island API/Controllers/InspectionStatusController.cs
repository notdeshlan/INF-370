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
    public class InspectionStatusController : ControllerBase
    {
        private readonly Platinum_Island_DatabaseContext _context;

        public InspectionStatusController(Platinum_Island_DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/InspectionStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InspectionStatus>>> GetInspectionStatuses()
        {
          if (_context.InspectionStatuses == null)
          {
              return NotFound();
          }
            return await _context.InspectionStatuses.ToListAsync();
        }

        // GET: api/InspectionStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InspectionStatus>> GetInspectionStatus(int id)
        {
          if (_context.InspectionStatuses == null)
          {
              return NotFound();
          }
            var inspectionStatus = await _context.InspectionStatuses.FindAsync(id);

            if (inspectionStatus == null)
            {
                return NotFound();
            }

            return inspectionStatus;
        }

        // PUT: api/InspectionStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInspectionStatus(int id, InspectionStatus inspectionStatus)
        {
            if (id != inspectionStatus.InspectionStatusId)
            {
                return BadRequest();
            }

            _context.Entry(inspectionStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InspectionStatusExists(id))
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

        // POST: api/InspectionStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InspectionStatus>> PostInspectionStatus(InspectionStatus inspectionStatus)
        {
          if (_context.InspectionStatuses == null)
          {
              return Problem("Entity set 'Platinum_Island_DatabaseContext.InspectionStatuses'  is null.");
          }
            _context.InspectionStatuses.Add(inspectionStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInspectionStatus", new { id = inspectionStatus.InspectionStatusId }, inspectionStatus);
        }

        // DELETE: api/InspectionStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInspectionStatus(int id)
        {
            if (_context.InspectionStatuses == null)
            {
                return NotFound();
            }
            var inspectionStatus = await _context.InspectionStatuses.FindAsync(id);
            if (inspectionStatus == null)
            {
                return NotFound();
            }

            _context.InspectionStatuses.Remove(inspectionStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InspectionStatusExists(int id)
        {
            return (_context.InspectionStatuses?.Any(e => e.InspectionStatusId == id)).GetValueOrDefault();
        }
    }
}
