using ApiBackEnd.DataAccess;
using ApiBackEnd.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace ApiBackEnd.Services
{
    public class CourseService : ICourseService
    {
        private readonly AplicationDbContext _context;
        public CourseService(AplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Course>> GetCourseByStudent(int IdStudent)
        {
            var resultado = await _context.Course.Where(value =>
            value.Students.FirstOrDefault(s => s.Id == IdStudent) != null
            ).ToListAsync();
            return resultado;
        }

        public async Task<IEnumerable<Course>> GetCoursesByCategory(string category)
        {
            var resultado = await _context.Course.Where(value =>
             value.Categories.Where(c => c.Name.Equals(category)).Count() > 0
             ).ToListAsync();
            return resultado;
        }

        public async Task<IEnumerable<Course>> GetCoursesWithCeroChapters()
        {
            var resultado = await _context.Course.Where(value =>
                string.IsNullOrEmpty(value.Chapter.List)
                ).ToListAsync();
            return resultado;
        }
    }
}
