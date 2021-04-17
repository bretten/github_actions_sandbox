using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine($"Input was: {args[i]}");
            }
            Console.WriteLine("No more arguments, stopping...");
        }
    }
}