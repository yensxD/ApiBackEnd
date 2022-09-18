using ApiBackEnd.DataAccess;
using ApiBackEnd.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace ApiBackEnd.Services
{
    public class StudentService : IStudentService
    {
        private readonly AplicationDbContext _context;
        public StudentService(AplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Student>> GetStudentByCourse(string course)
        {
            var resultado = await _context.Student.Where(value =>
               value.Courses.Where(c => c.Name.Equals(course)).Count() > 0
               ).ToListAsync();
            return resultado;
        }

        public async Task<IEnumerable<Student>> GetStudentsWithCeroCourses()
        {
            var resultado = await _context.Student.Where(value =>
              value.Courses.Count() == 0
              ).ToListAsync();
            return resultado;
        }
    }
}
