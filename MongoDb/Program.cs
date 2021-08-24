using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDb.Interfaces;
using MongoDb.Services;
using MongoDb.Workers;

namespace MongoDb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<ILogService, LogService>();

                    services.AddHostedService<CreateLogsWorker>();
                    services.AddHostedService<ReadPendingLogsWorker>();
                });
    }
}
