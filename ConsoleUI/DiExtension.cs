using System.Reflection;
using System;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;
using ConsoleUI.Framework;
using System.Linq;

namespace ConsoleUI.Extensions.DependencyInjection
{
    public static class DiExtension
    {
        public static IServiceCollection AddConsoleUIServices(this IServiceCollection services) {
            services.AddSingleton<IAnsiConsole>(_ => AnsiConsole.Console);
            services.AddSingleton<Root>();
            var assembly = Assembly.GetAssembly(typeof(UIAction));
            if (assembly == null) {
                throw new InvalidOperationException("Could not find assembly");
            }
            var types = assembly.GetTypes().Where(x => x.GetInterfaces().Any() && x.IsAbstract == false).ToList();
            foreach(var type in types) {
                services.AddSingleton(type);
            }
            return services;
        }
    }
}
