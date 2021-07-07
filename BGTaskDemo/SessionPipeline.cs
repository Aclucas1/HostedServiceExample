﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BGTaskDemo
{
    public class SessionPipeline : IHostedService, IDisposable
    {
        private Timer timer;

        // had to implement this to dispose the timer
        public void Dispose()
        {
            timer?.Dispose();
        }

        // on service start
        public Task StartAsync(CancellationToken cancellationToken)
        {
            Worker worker = new Worker(); // our worker class for the pipeline

            timer = new Timer(o =>
                { // Callback for the timer
                    if (worker.ShouldRun())
                    {
                        worker.DoWork("Session");
                    }
                    else
                    {
                        Console.WriteLine("Not time to work on Session");
                    }
                },
                null, // not sure but example said leave null
                TimeSpan.Zero, // basically means start immediately 
                TimeSpan.FromSeconds(2) // How often should we check for work? 
            );
            return Task.CompletedTask;
        }

        // on service stop 
        public Task StopAsync(CancellationToken cancellationToken)
        {
            // just logging that the service stopped for now 
            Console.WriteLine("Printing worker stopped");
            return Task.CompletedTask;
        }
    }
}
