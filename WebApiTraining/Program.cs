using System.IO;
using System.Reflection;
using log4net;
using log4net.Config;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace WebApiTraining
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var logRepo = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepo, new FileInfo("log4net.config"));

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureLogging((webHostBuilderContext, loggingBuilder) =>
                {
                    loggingBuilder.AddLog4Net();
                })
                .UseStartup<Startup>();
    }
}
