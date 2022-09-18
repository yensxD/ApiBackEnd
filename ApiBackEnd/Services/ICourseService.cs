using ApiBackEnd.Models.DataModels;

namespace ApiBackEnd.Services
{
    public interface ICourseService
    {
  
        Task<IEnumerable<Course>> GetCoursesByCategory(string category);
        
        Task<IEnumerable<Course>> GetCoursesWithCeroChapters();
        
        Task<IEnumerable<Course>> GetCourseByStudent(int IdStudent);


    }
}
