using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Model.Postgres
{
    //Provides a context for developer migrations
    public class WellbeingDevContextProvider : IDesignTimeDbContextFactory<WellbeingDbContext>
    {
        public const string ConnectionString = "Host=localhost;Database=wellbeingdb;Username=admin;Password=Simple22Simple";

        public WellbeingDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<WellbeingDbContext>();
            optionsBuilder.UseNpgsql(
                ConnectionString, 
                x => x.MigrationsAssembly("Model.Postgres"));
            
            return new WellbeingDbContext(optionsBuilder.Options);
        }
    }
}