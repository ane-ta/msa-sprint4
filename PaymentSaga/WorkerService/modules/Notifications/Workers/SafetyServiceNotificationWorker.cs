using WorkerService.modules.Payments.DTOs;
using WorkerService.Shared.Contracts;
using Zeebe.Client.Accelerator.Abstractions;
using Zeebe.Client.Accelerator.Attributes;

namespace WorkerService.modules.Notifications.Workers
{
	[JobType("AutoRejectedTransactionNotificating")]
	internal class SafetyServiceNotificationWorker : IAsyncZeebeWorker
	{
		private readonly ILogger<SafetyServiceNotificationWorker> _logger;

		public SafetyServiceNotificationWorker(ILogger<SafetyServiceNotificationWorker> logger)
		{
			_logger = logger;
		}

		public async Task HandleJob(ZeebeJob job, CancellationToken cancellationToken)
		{
			var info = job.getVariables<OrderPaymentInfo>();

			_logger.LogInformation($"[{job.Key}] Notifying safety service about order payment status... {info.OrderId}");
		}
	}
}
