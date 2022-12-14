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
    public class ChaptersController : ControllerBase
    {
        private readonly AplicationDbContext _context;
        private IChapterService _services;
        public ChaptersController(AplicationDbContext context, IChapterService services)
        {
            _context = context;
            _services = services;
        }

        // GET: api/GetChapterByCourse/{course}
        [HttpGet("{course}")]
        public async Task<ActionResult<Chapter?>> GetChapterByCourse(string course)
        {
            return await _services.GetChapterByCourse(course);
        }

        // GET: api/Chapters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chapter>>> GetChapter()
        {
            return await _context.Chapter.ToListAsync();
        }

        // GET: api/Chapters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Chapter>> GetChapter(int id)
        {
            var chapter = await _context.Chapter.FindAsync(id);

            if (chapter == null)
            {
                return NotFound();
            }

            return chapter;
        }

        // PUT: api/Chapters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChapter(int id, Chapter chapter)
        {
            if (id != chapter.Id)
            {
                return BadRequest();
            }

            _context.Entry(chapter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChapterExists(id))
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

        // POST: api/Chapters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Chapter>> PostChapter(Chapter chapter)
        {
            _context.Chapter.Add(chapter);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChapter", new { id = chapter.Id }, chapter);
        }

        // DELETE: api/Chapters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChapter(int id)
        {
            var chapter = await _context.Chapter.FindAsync(id);
            if (chapter == null)
            {
                return NotFound();
            }

            _context.Chapter.Remove(chapter);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChapterExists(int id)
        {
            return _context.Chapter.Any(e => e.Id == id);
        }
    }
}
