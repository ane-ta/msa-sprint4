using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerService.modules.Payments.DTOs;
using WorkerService.modules.Security.DTOs;
using WorkerService.Shared.Contracts;
using WorkerService.Shared.Infrustructure;
using Zeebe.Client.Accelerator.Abstractions;
using Zeebe.Client.Accelerator.Attributes;

namespace WorkerService.modules.Notifications.Workers
{	
	[JobType("SuccessClientNotificating")]
	internal class SuccessClientNotificationWorker : AsyncZeebeActionWorker<OrderPaymentBusinessKey>
	{
		private readonly ILogger<SuccessClientNotificationWorker> _logger;

		public SuccessClientNotificationWorker(ILogger<SuccessClientNotificationWorker> logger):base(logger)
		{
			_logger = logger;
		}

		protected override Task HandleJobInnerAction(ZeebeJob job, CancellationToken cancellationToken)
		{
			return Task.CompletedTask;
		}
	}
}