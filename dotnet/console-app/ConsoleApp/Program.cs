using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            do
            {
                input = Console.ReadLine();
                Console.WriteLine($"Input was: {input}");
            } while (!string.IsNullOrWhiteSpace(input));

            Console.WriteLine("Input was empty, stopping...");
        }
    }
}