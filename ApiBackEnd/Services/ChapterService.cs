using ApiBackEnd.DataAccess;
using ApiBackEnd.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace ApiBackEnd.Services
{
    public class ChapterService : IChapterService
    {
        private readonly AplicationDbContext _context;
        public ChapterService(AplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Chapter?> GetChapterByCourse(string course)
        {
            var resultado = await _context.Chapter.Where(value =>
                value.Course.Name.Equals(course)
                ).FirstOrDefaultAsync();
            return resultado;
        }
    }
}
