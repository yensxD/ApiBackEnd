using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiBackEnd.DataAccess;
using ApiBackEnd.Models.DataModels;
using ApiBackEnd.Services;

namespace ApiBackEnd.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly AplicationDbContext _context;
        private ICourseService _services;

        public CoursesController(AplicationDbContext context, ICourseService services)
        {
            _context = context;
            _services = services;
        }
        // GET: api/GetCoursesByCategory/{category}
        [HttpGet("{category}")]
        public async Task<ActionResult<IEnumerable<Course>>> GetCoursesByCategory(string category)
        {
            var resultado = await _services.GetCoursesByCategory(category);
            return resultado.ToList();
        }
        // GET: api/GetCoursesWithCeroChapters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCoursesWithCeroChapters()
        {
            var resultado = await _services.GetCoursesWithCeroChapters();
            return resultado.ToList();
        }
        // GET: api/GetCourseByStudent/{}
        [HttpGet("{IdStudent}")]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourseByStudent(int IdStudent)
        {
            var resultado = await _services.GetCourseByStudent(IdStudent);
            return resultado.ToList();
        }

        // GET: api/Courses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourse()
        {
            return await _context.Course.ToListAsync();
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(int id)
        {
            var course = await _context.Course.FindAsync(id);

            if (course == null)
            {
                return NotFound();
            }

            return course;
        }

        // PUT: api/Courses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(int id, Course course)
        {
            if (id != course.Id)
            {
                return BadRequest();
            }

            _context.Entry(course).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
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

        // POST: api/Courses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Course>> PostCourse(Course course)
        {
            _context.Course.Add(course);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCourse", new { id = course.Id }, course);
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _context.Course.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            _context.Course.Remove(course);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CourseExists(int id)
        {
            return _context.Course.Any(e => e.Id == id);
        }
    }
}
