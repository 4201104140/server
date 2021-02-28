using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.BackgroundTasks.Tasks
{
    public class GracePeriodManagerService : BackgroundService
    {
        private readonly ILogger<GracePeriodManagerService> _logger;
        private readonly BackgroundTaskSettings _settings;

        public GracePeriodManagerService(IOptions<BackgroundTaskSettings> settings, ILogger<GracePeriodManagerService> logger)
        {
            _settings = settings?.Value ?? throw new ArgumentNullException(nameof(settings));

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogDebug("GracePeriodManagerService is starting.");

            stoppingToken.Register(() => _logger.LogDebug("#1 GracePeriodMangerService background task is stoppping."));

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogDebug("GracePeriodManagerService background task is doing background task is stopping");

                await Task.Delay(_settings.CheckUpdateTime, stoppingToken);
            }

            _logger.LogDebug("GracePeriodManagerService background task is stopping.");
        }

        private void CheckConfirmedGracePeriodOrders()
        {
            _logger.LogDebug("Checking confirmed grace period orders");

            //var orderIds = 
        }
    }
}
