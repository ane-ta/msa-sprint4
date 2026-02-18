using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerService.modules.Payments.DTOs;
using WorkerService.Shared.Contracts;
using Zeebe.Client.Accelerator.Abstractions;
using Zeebe.Client.Accelerator.Attributes;

namespace WorkerService.modules.Notifications.Workers
{	
	[JobType("SuccessClientNotificating")]
	internal class SuccessClientNotificationWorker : IAsyncZeebeWorker
	{
		private readonly ILogger<SuccessClientNotificationWorker> _logger;

		public SuccessClientNotificationWorker(ILogger<SuccessClientNotificationWorker> logger)
		{
			_logger = logger;
		}

		public async Task HandleJob(ZeebeJob job, CancellationToken cancellationToken)
		{
			var info = job.getVariables<OrderPaymentInfo>();

			_logger.LogInformation($"[{job.Key}] Notifying client about successful payment for {info.OrderId}...");
		}
	}
}