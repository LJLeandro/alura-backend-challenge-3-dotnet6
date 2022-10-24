using alura_backend_challenge_3.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace alura_backend_challenge_3.Models.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext(DbContextOptions<MySQLContext> options) : base (options) { }

        public DbSet<VideoEntity> Videos { get; set; }
    }
}
