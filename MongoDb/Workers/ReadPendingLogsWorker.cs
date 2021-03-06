using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MongoDb.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MongoDb.Workers
{
    public class ReadPendingLogsWorker : BackgroundService
    {
        private readonly ILogger<CreateLogsWorker> _logger;
        private readonly ILogService _logService;
        public ReadPendingLogsWorker(
                ILogger<CreateLogsWorker> logger,
                ILogService logService)
        {
            _logger = logger;
            _logService = logService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    var item = _logService.FindPending();
                    item.SetResolved();
                    _logService.Update(item.Id, item);
                    _logger.LogInformation($"Pendência Solucionada :: { item.Id }");

                    await Task.Delay(1500, stoppingToken);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ ex.ToString() }");
            }
        }
    }
}
