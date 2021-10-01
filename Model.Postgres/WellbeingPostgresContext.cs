using Microsoft.EntityFrameworkCore;

namespace Model.Postgres
{
    public class WellbeingPostgresContext : WellbeingDbContext
    {
          protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql();
    }
}