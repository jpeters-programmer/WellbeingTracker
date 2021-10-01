using System.Reflection;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace API.Extensions.DependencyInjection
{
    public static class DiExtension
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services) {           
            var assembly = Assembly.GetAssembly(typeof(IController));
            if (assembly == null) {
                throw new InvalidOperationException("Could not find assembly");
            }            
            var types = assembly.GetTypes().Where(x => x.IsClass && x.GetInterfaces().Any() && x.IsAbstract == false).ToList();
            foreach(var type in types) {
                services.AddSingleton(type);
            }        
            return services;
        }
    }
}
