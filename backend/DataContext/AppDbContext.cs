using backend.Model;
using Microsoft.EntityFrameworkCore;

namespace backend.DataContext
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<Entidade> Entidade { get; set; }
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<Estado> Estado { get; set; }

        public DbSet<Usuario> Usuario { get; set; }

        public AppDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("connectionString"));
        }
    }
}
