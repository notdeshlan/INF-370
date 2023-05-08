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
    public class EmployeeTypesController : ControllerBase
    {
        private readonly Platinum_Island_DatabaseContext _context;

        public EmployeeTypesController(Platinum_Island_DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeType>>> GetEmployeeTypes()
        {
          if (_context.EmployeeTypes == null)
          {
              return NotFound();
          }
            return await _context.EmployeeTypes.ToListAsync();
        }

        // GET: api/EmployeeTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeType>> GetEmployeeType(int id)
        {
          if (_context.EmployeeTypes == null)
          {
              return NotFound();
          }
            var employeeType = await _context.EmployeeTypes.FindAsync(id);

            if (employeeType == null)
            {
                return NotFound();
            }

            return employeeType;
        }

        // PUT: api/EmployeeTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeType(int id, EmployeeType employeeType)
        {
            if (id != employeeType.EmployeeTypeId)
            {
                return BadRequest();
            }

            _context.Entry(employeeType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeTypeExists(id))
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

        // POST: api/EmployeeTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeeType>> PostEmployeeType(EmployeeType employeeType)
        {
          if (_context.EmployeeTypes == null)
          {
              return Problem("Entity set 'Platinum_Island_DatabaseContext.EmployeeTypes'  is null.");
          }
            _context.EmployeeTypes.Add(employeeType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeType", new { id = employeeType.EmployeeTypeId }, employeeType);
        }

        // DELETE: api/EmployeeTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeType(int id)
        {
            if (_context.EmployeeTypes == null)
            {
                return NotFound();
            }
            var employeeType = await _context.EmployeeTypes.FindAsync(id);
            if (employeeType == null)
            {
                return NotFound();
            }

            _context.EmployeeTypes.Remove(employeeType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeTypeExists(int id)
        {
            return (_context.EmployeeTypes?.Any(e => e.EmployeeTypeId == id)).GetValueOrDefault();
        }
    }
}
