using Microsoft.EntityFrameworkCore;
using WebApi_Net6_PostgreSQL.Entities;

namespace WebApi_Net6_PostgreSQL.Helpers {
    public class DataContext : DbContext {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration) {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) {
            // connect to postgres with connection string from app settings
            options.UseNpgsql(Configuration.GetConnectionString("ApiDataBase")).UseSnakeCaseNamingConvention();
        }
        public DbSet<User> Users { get; set; }
    }
}
