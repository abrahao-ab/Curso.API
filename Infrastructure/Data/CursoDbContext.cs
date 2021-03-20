using Curso.API.Business.Entities;
using Curso.API.Infrastructure.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Curso.API.Infrastructure.Data
{
    public class CursoDbContext : DbContext
    {
        public CursoDbContext(DbContextOptions<CursoDbContext> options) : base(options)
            {
        
            }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CursoMapping());
            modelBuilder.ApplyConfiguration(new UsuarioMapping());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<curso> Curso { get; set; }



    }
}
