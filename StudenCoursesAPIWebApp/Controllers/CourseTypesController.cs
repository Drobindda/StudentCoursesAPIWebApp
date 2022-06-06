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
    public class CourseTypesController : ControllerBase
    {
        private readonly StudentCoursesAPIContext _context;

        public CourseTypesController(StudentCoursesAPIContext context)
        {
            _context = context;
        }

        // GET: api/CourseTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseType>>> GetCourseTypes()
        {
          if (_context.CourseTypes == null)
          {
              return NotFound();
          }
            return await _context.CourseTypes.ToListAsync();
        }

        // GET: api/CourseTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseType>> GetCourseType(int id)
        {
          if (_context.CourseTypes == null)
          {
              return NotFound();
          }
            var courseType = await _context.CourseTypes.FindAsync(id);

            if (courseType == null)
            {
                return NotFound();
            }

            return courseType;
        }

        // PUT: api/CourseTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourseType(int id, CourseType courseType)
        {
            if (id != courseType.Id)
            {
                return BadRequest();
            }

            _context.Entry(courseType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseTypeExists(id))
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

        // POST: api/CourseTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CourseType>> PostCourseType(CourseType courseType)
        {
          if (_context.CourseTypes == null)
          {
              return Problem("Entity set 'StudentCoursesAPIContext.CourseTypes'  is null.");
          }
            _context.CourseTypes.Add(courseType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCourseType", new { id = courseType.Id }, courseType);
        }

        // DELETE: api/CourseTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourseType(int id)
        {
            if (_context.CourseTypes == null)
            {
                return NotFound();
            }
            var courseType = await _context.CourseTypes.FindAsync(id);
            if (courseType == null)
            {
                return NotFound();
            }

            _context.CourseTypes.Remove(courseType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CourseTypeExists(int id)
        {
            return (_context.CourseTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
