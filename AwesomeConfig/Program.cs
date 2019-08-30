using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace AwesomeConfig
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("awesomeConfig.json");

            var awesomeOptions = new AwesomeConfig.Models.AwesomeConfig();
            builder.Build().Bind(awesomeOptions);

            System.Console.WriteLine(awesomeOptions.Name);
            System.Console.WriteLine(awesomeOptions.LastName);
            System.Console.WriteLine(awesomeOptions.Age);

            Console.ReadKey();
        }
    }
}
