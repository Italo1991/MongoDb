using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MongoDb.Events;
using MongoDb.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MongoDb.Workers
{
    public class CreateLogsWorker : BackgroundService
    {
        private readonly ILogger<CreateLogsWorker> _logger;
        private readonly ILogService _logService;
        public CreateLogsWorker(
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
                    var item = new LogEvent("Descrição da pendência","Minha Pendência");
                    var created =_logService.Create(item);
                    _logger.LogInformation($"Pendência criada :: { created.Id }");

                    await Task.Delay(1000, stoppingToken);
                }
            }
            catch(Exception ex)
            {
                _logger.LogError($"{ ex.ToString() }");
            }
        }
    }
}
