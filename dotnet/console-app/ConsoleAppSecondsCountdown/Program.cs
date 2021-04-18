using System;
using System.Threading;

namespace ConsoleAppSecondsCountdown
{
    class Program
    {
        static void Main(string[] args)
        {
            string jobName = args[0];
            int seconds = int.Parse(args[1]);

            while (seconds > -1)
            {
                Console.WriteLine($"Job {jobName}: {seconds}");
                Thread.Sleep(TimeSpan.FromSeconds(1));
                seconds--;
            }
            Console.WriteLine($"Job {jobName} done");
        }
    }
}