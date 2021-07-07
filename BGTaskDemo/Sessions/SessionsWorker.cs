using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BGTaskDemo
{
    class SessionsWorker : IWorker
    {
        private int number = 0;

        public void DoWork(string pipeline)
        {
            Console.WriteLine($"Run {pipeline} update logic here");
        }

        public bool ShouldRun()
        {
            number += 1;

            if (number % 5 == 0)
            {
                return true;
            }

            return false;
        }
    }
}
