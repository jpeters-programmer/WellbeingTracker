using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using ConsoleUI.Extensions.DependencyInjection;
using API.Extensions.DependencyInjection;
using Model.Postgres.Extensions.DependencyInjection;

namespace ConsoleHost
{
    class Program
    {
        static Task Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();              
            return host.RunAsync();
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) => services                    
                    .AddHostedService<ConsoleUIHost>()
                    .AddApiServices()
                    .AddWellbeingContext_Dev()
                    .AddConsoleUIServices());
    }
}
