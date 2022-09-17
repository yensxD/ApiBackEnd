using ApiBackEnd.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace ApiBackEnd.DataAccess
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {

        }

        public DbSet<User>? User { get; set; }
        public DbSet<Curso> Curso { get; set; }



    }
}
