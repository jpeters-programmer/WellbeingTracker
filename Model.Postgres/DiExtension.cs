using System.Reflection;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Model.Postgres;

namespace Model.Postgres.Extensions.DependencyInjection
{
    public static class DiExtension
    {
        public static IServiceCollection AddWellbeingContext(this IServiceCollection services, string connectionString) {           
            services.AddDbContext<WellbeingDbContext>(options => options.UseNpgsql(connectionString));
            return services;
        }

        public static IServiceCollection AddWellbeingContext_Dev(this IServiceCollection services) {           
            services.AddDbContext<WellbeingDbContext>(options => options.UseNpgsql(WellbeingDevContextProvider.ConnectionString));
            return services;
        }
    }
}
