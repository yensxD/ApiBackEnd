using ApiBackEnd.Models.DataModels;

namespace ApiBackEnd.Services
{
    public interface IStudentService
    { 
        Task<IEnumerable<Student>> GetStudentsWithCeroCourses();
        Task<IEnumerable<Student>> GetStudentByCourse(string course);

    }
}
