using WorkerService.Shared.Contracts;
using WorkerService.Shared.Infrustructure;
using Zeebe.Client.Accelerator.Abstractions;
using Zeebe.Client.Accelerator.Attributes;

namespace WorkerService.modules.Notifications.Workers
{
	[JobType("RevertClientNotificating")]
	internal class RevertClientNotificationWorker : AsyncZeebeActionWorker<OrderPaymentBusinessKey>
	{
		private readonly ILogger<RevertClientNotificationWorker> _logger;

		public RevertClientNotificationWorker(ILogger<RevertClientNotificationWorker> logger) : base (logger)
		{
			_logger = logger;
		}

		protected override Task HandleJobInnerAction(ZeebeJob job, CancellationToken cancellationToken)
		{
			return Task.CompletedTask;
		}
	}
}