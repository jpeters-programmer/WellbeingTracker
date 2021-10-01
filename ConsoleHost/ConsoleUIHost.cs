using System;
using System.Threading;
using System.Threading.Tasks;
using ConsoleUI;
using Microsoft.Extensions.Hosting;

namespace ConsoleHost
{
    public class ConsoleUIHost : IHostedService
    { 
        private ConsoleUI.Root _root;

        public ConsoleUIHost(Root root)
        {
            _root = root;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            return Task.Run(()=> {
                _root.Run();
            });            
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
           return Task.CompletedTask;
        }
    }
}