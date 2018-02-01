using System;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Runtime.Versioning;

namespace tls_negotiations
{
    class Program
    {
        static void Main(string[] args)
        {
            TargetFrameworkAttribute targetFw = (TargetFrameworkAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(System.Runtime.Versioning.TargetFrameworkAttribute), false)[0];

            Console.WriteLine($"Baked in target for this binary: {targetFw.FrameworkName}");
            Console.WriteLine($"ServicePointManager.SecurityProtocol returned: {ServicePointManager.SecurityProtocol}");

            HttpClient c = new HttpClient();
            HttpResponseMessage res = new HttpResponseMessage();

            try
            {
                res = c.GetAsync("https://pages.github.io").Result;
                Console.WriteLine("\nResponse:\n");
                Console.WriteLine(res.Headers.ToString());
            }
            catch (Exception ex)
            {
                WriteException(ex.InnerException.InnerException.Message);
            }

            Console.ReadLine();
        }

        static void WriteException(String message)
        {
            var oldColor = Console.BackgroundColor;
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(message);
            Console.BackgroundColor = oldColor;
        }
    }
}
