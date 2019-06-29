using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace TaskWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((contextBuilder, config) =>
                {
                    config.AddJsonFile("appsettings.json", false, true);
                    config.AddJsonFile($"appsettings.{contextBuilder.HostingEnvironment.EnvironmentName}.json");
                    config.AddEnvironmentVariables();

                    if (args.Any())
                        config.AddCommandLine(args);


                })
                .ConfigureLogging((hosting, config) =>
                {
                    config.AddConfiguration(hosting.Configuration.GetSection("Logging"));
                    config.AddConsole();
                    config.AddDebug();
                })
                .UseStartup<Startup>();
    }
}
