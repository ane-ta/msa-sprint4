using WorkerService.modules.Payments.DTOs;
using WorkerService.modules.Security.DTOs;
using WorkerService.Shared;
using WorkerService.Shared.Contracts;
using WorkerService.Shared.Infrustructure;
using Zeebe.Client.Accelerator.Abstractions;
using Zeebe.Client.Accelerator.Attributes;

namespace WorkerService.modules.Notifications.Workers
{
	[JobType("AutoRejectedTransactionNotificating")]
	internal class SafetyServiceNotificationWorker : AsyncZeebeFuncWorker<OrderPaymentBusinessKey, Unit>
	{
		private readonly ILogger<SafetyServiceNotificationWorker> _logger;

		public SafetyServiceNotificationWorker(ILogger<SafetyServiceNotificationWorker> logger) : base(logger)
		{
			_logger = logger;
		}

		//protected override Task HandleJobInnerAction(ZeebeJob job, CancellationToken cancellationToken)
		//{
		//	return Task.CompletedTask;
		//}

		protected override Task<Unit> HandleJobInnerFunction(ZeebeJob job, CancellationToken cancellationToken)
		{
			return Task.FromResult(new Unit());
		}
	}
}
