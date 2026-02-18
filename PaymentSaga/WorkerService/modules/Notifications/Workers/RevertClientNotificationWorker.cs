using WorkerService.Shared.Contracts;
using Zeebe.Client.Accelerator.Abstractions;
using Zeebe.Client.Accelerator.Attributes;

namespace WorkerService.modules.Notifications.Workers
{
	[JobType("RevertClientNotificating")]
	internal class RevertClientNotificationWorker : IAsyncZeebeWorker
	{
		private readonly ILogger<RevertClientNotificationWorker> _logger;

		public RevertClientNotificationWorker(ILogger<RevertClientNotificationWorker> logger)
		{
			_logger = logger;
		}

		public async Task HandleJob(ZeebeJob job, CancellationToken cancellationToken)
		{
			var info = job.getVariables<OrderPaymentInfo>();

			_logger.LogInformation($"[{job.Key}] Notifying client about reverted payment... {info.OrderId}");
		}
	}
}