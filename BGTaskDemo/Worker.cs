using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BGTaskDemo
{
    // Generic version of worker class that can be replicated for each table to update
    class Worker
    {
        // Replace this with sql call for last run info
        private int number = 0;

        // do the work for the update
        public void DoWork()
        {
            Console.WriteLine($"Run update logic here");
        }

        // is it time to run calculation base off last run data
        public bool ShouldRun()
        {
            number += 1;

            // fake calc for "time to run" example
            if (number % 5 == 0)
            {
                return true;
            }

            return false;
        }
    }
}
