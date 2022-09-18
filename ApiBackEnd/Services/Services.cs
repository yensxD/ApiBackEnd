using ApiBackEnd.DataAccess;
using ApiBackEnd.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace ApiBackEnd.Services
{
    public class Services
    {
        private readonly AplicationDbContext _context;

        public Services(AplicationDbContext context)
        {
            _context = context;
        }


        public async Task<User?> FindUsersByEmail(string Email)
        {
            var resultado = await _context.User.Where(value => value.Email.Equals(Email)).FirstOrDefaultAsync();
            return resultado;
        }
        public async Task<IEnumerable<Student>> FindOlderStudents()
        {
            var resultado = await _context.Student.Where(value => (DateTime.Now.Year - value.Dob.Year) >= 18).ToListAsync();
            return resultado;
        }

        public async Task<IEnumerable<Student>> FindStudentsByCourseThanOrEqualOne()
        {
            var resultado = await _context.Student.Where(value => value.Courses.Count() >= 1 ).ToListAsync();
            return resultado;
        }

        public async Task<IEnumerable<Course>> FindCourseStundentThanOrEqualToOneByLevel(Level level)
        {
            var resultado = await _context.Course.Where(value => 
                value.level == Level.Medium &&
                value.Students.Count()>=1
                ).ToListAsync();
            return resultado;
        }

        public async Task<IEnumerable<Course>> FindCoursesByCategoryAndLevel(string category, Level level)
        {
            var resultado = await _context.Course.Where(value =>
                value.level == level &&
                value.Categories.Where(cat => cat.Name.Equals(category)).Count()>=1
                ).ToListAsync();
            return resultado;
        }

        public async Task<IEnumerable<Course>> FindCoursesWithCeroStudents()
        {
            var resultado = await _context.Course.Where(value =>
                value.Students.Count() >= 0
                ).ToListAsync();
            return resultado;
        }


    }
}
