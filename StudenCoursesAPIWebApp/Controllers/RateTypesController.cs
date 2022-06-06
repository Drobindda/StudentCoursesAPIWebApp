using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentCoursesAPIWebApp.Models;

namespace StudentCoursesAPIWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateTypesController : ControllerBase
    {
        private readonly StudentCoursesAPIContext _context;

        public RateTypesController(StudentCoursesAPIContext context)
        {
            _context = context;
        }

        // GET: api/RateTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RateType>>> GetRateTypes()
        {
          if (_context.RateTypes == null)
          {
              return NotFound();
          }
            return await _context.RateTypes.ToListAsync();
        }

        // GET: api/RateTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RateType>> GetRateType(int id)
        {
          if (_context.RateTypes == null)
          {
              return NotFound();
          }
            var rateType = await _context.RateTypes.FindAsync(id);

            if (rateType == null)
            {
                return NotFound();
            }

            return rateType;
        }

        // PUT: api/RateTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRateType(int id, RateType rateType)
        {
            if (id != rateType.Id)
            {
                return BadRequest();
            }

            _context.Entry(rateType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RateTypeExists(id))
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

        // POST: api/RateTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RateType>> PostRateType(RateType rateType)
        {
          if (_context.RateTypes == null)
          {
              return Problem("Entity set 'StudentCoursesAPIContext.RateTypes'  is null.");
          }
            _context.RateTypes.Add(rateType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRateType", new { id = rateType.Id }, rateType);
        }

        // DELETE: api/RateTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRateType(int id)
        {
            if (_context.RateTypes == null)
            {
                return NotFound();
            }
            var rateType = await _context.RateTypes.FindAsync(id);
            if (rateType == null)
            {
                return NotFound();
            }

            _context.RateTypes.Remove(rateType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RateTypeExists(int id)
        {
            return (_context.RateTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
