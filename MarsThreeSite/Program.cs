using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MarsThreeLogging;
using Microsoft.Extensions.DependencyInjection;
using MarsThreeSite.Controllers.Data_Access;

namespace MarsThreeSite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
            //Raden för att konfigurera loggningen, AddDebug är den inbyggda och vill jag lägga in min egen så bygger jag en och includerar den genom AddProvider
            .ConfigureLogging(logging => { logging.AddDebug(); }) //logging.AddProvider(new MarsThreeLoggerProvider()); }) 
            .UseStartup<Startup>()
            .ConfigureServices(ConfigureService)
            .Build();
        }

        // Kolla upp hur jag göra för att skicka in en metod i en delegat
        public static void ConfigureService(IServiceCollection service)
        {
            service.AddScoped<IPageRepository, PageRepository>();
        }
    }
}
