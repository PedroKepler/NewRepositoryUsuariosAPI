using Usuarios.Models;
using Microsoft.EntityFrameworkCore;

namespace Usuarios.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public virtual DbSet<Usuario> UsuariosAPI { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasData(

              new Usuario
              {
                  Id = 1,
                  Nome = "Marcos de Oliveira",
                  Email = "MarcosDeOliveira@yahoo.com",
                  Idade = 23
              },
             new Usuario
             {
                 Id = 2,
                 Nome = "Maria de Oliveira",
                 Email = "MariaDeOliveira@yahoo.com",
                 Idade = 23
             }
        );
        }
    }


}
