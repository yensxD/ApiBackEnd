using ApiBackEnd.Models.DataModels;

namespace ApiBackEnd.Services
{
    public interface IChapterService
    {
          Task<Chapter?> GetChapterByCourse(string course);
 
    }
}
