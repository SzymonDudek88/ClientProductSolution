using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => // to nam ustawia mozliwosci ktore wykorzystamy juz w Startup ponizej
                // jak np DI dla jakichs dzia�a� i s� one tylko 3 Iconfiguration...
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
