using Microsoft.EntityFrameworkCore;

namespace EnvironmentSinkHole.DBContext
{
    public class EnvironmentDbContext : DbContext
    {
        public EnvironmentDbContext(DbContextOptions<EnvironmentDbContext> options) :
           base(options)
        {

        }
        public DbSet<EnvData>? EnvironmentDump { get; set; }

    }
}