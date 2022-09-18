using ApiBackEnd.Models.DataModels;

namespace ApiBackEnd.Services
{
    public interface IServices
    {
        Task<User?> FindUsersByEmail(string Email);
        Task<IEnumerable<Student>> FindOlderStudents();
        Task<IEnumerable<Student>> FindStudentsByCourseThanOrEqualOne();
        Task<IEnumerable<Course>> FindCourseStundentThanOrEqualToOneByLevel(Level level);
        Task<IEnumerable<Course>> FindCoursesByCategoryAndLevel(string category, Level level);
        Task<IEnumerable<Course>> FindCoursesWithCeroStudents();
  
    }
}
