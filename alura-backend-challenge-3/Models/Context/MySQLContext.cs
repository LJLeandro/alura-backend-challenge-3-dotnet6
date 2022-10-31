using alura_backend_challenge_3.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace alura_backend_challenge_3.Models.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext(DbContextOptions<MySQLContext> options) : base (options) { }

        public DbSet<VideoEntity> Videos { get; set; }
        public DbSet<CategoriaEntity> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CategoriaEntity>()
                            .HasMany(t => t.Videos)
                            .WithOne(t => t.Categoria)
                            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CategoriaEntity>().HasData(new CategoriaEntity()
            {
                Id = 1,
                Titulo = "LIVRE",
                Cor = "Branco"
            });
        }
    }
}
