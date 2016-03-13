using System;
using System.Threading;

namespace MemoryLeak
{
    public class Scheduler
    {
        public event EventHandler Cancel;
    }

    public class Worker
    {
        private byte[] _data;
        private Scheduler _scheduler;

        public Worker(Scheduler scheduler)
        {
            _data = new byte[1024 * 100];
            _scheduler = scheduler;

            _scheduler.Cancel += Scheduler_Cancel;
        }

        public void Work()
        {
            Thread.Sleep(50);
        }

        private void Scheduler_Cancel(object sender, EventArgs e)
        {
            Console.WriteLine("I'm canceled");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Scheduler scheduler = new Scheduler();

            while (true)
            {
                new Worker(scheduler).Work();
            }
        }
    }
}
