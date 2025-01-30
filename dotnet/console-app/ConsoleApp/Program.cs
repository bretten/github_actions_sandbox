using System;
using System.Diagnostics;
using System.Reflection;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var buildId = Environment.GetEnvironmentVariable("BUILD_ID");
            Console.WriteLine($"Build ID: {buildId}");

            var assembly = Assembly.GetExecutingAssembly();
            var assemblyVersion = assembly.GetName().Version;
            var assemblyFileVersion = assembly.GetCustomAttribute<AssemblyFileVersionAttribute>()?.Version;
            var informationalVersion = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                ?.InformationalVersion;

            Console.WriteLine($"Assembly Version: {assemblyVersion}");
            Console.WriteLine($"Assembly File Version: {assemblyFileVersion}");
            Console.WriteLine($"Informational Version: {informationalVersion}");

            var versionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly()!.Location);
            var productVersion = versionInfo.ProductVersion;
            var fileVersion = versionInfo.FileVersion;

            Console.WriteLine($"ProductVersion: {productVersion}");
            Console.WriteLine($"FileVersion: {fileVersion}");

            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine($"Input was: {args[i]}");
            }

            Console.WriteLine("No more arguments, stopping...");
        }
    }
}