using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BGTaskDemo
{
    public interface IPipeline : IHostedService, IDisposable { }
}