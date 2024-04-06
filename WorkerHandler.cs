using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroForSols
{
    internal class WorkerHandler
    {
        public bool Stopping { get; set; }
        public void DoWork()
        {
            while (!Stopping)
            {
                System.Diagnostics.Debug.WriteLine(DateTime.Now);
                Console.WriteLine("Stopped");
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
