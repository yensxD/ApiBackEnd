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
        public DbSet<Course> Course { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Chapter> Chapter { get; set; }
        public DbSet<Category> Category { get; set; }




    }
}
