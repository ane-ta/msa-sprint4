using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerService.modules.Payments.DTOs;
using WorkerService.modules.Security.DTOs;
using Zeebe.Client.Accelerator.Abstractions;
using Zeebe.Client.Accelerator.Attributes;

namespace WorkerService.modules.Security.Workers
{
	[JobType("AutoSafetyCheck")]
	internal class AutoSafetyCheckWorker : IAsyncZeebeWorkerWithResult<AutoSafetyCheckResult>
	{
		private readonly ILogger<AutoSafetyCheckWorker> _logger;

		public AutoSafetyCheckWorker(ILogger<AutoSafetyCheckWorker> logger)
		{
			_logger = logger;
		}

		public async Task<AutoSafetyCheckResult> HandleJob(ZeebeJob job, CancellationToken cancellationToken)
		{
			_logger.LogInformation("[{JobKey}] Running Safety AutoCheck...", job.Key);

			var info = job.getVariables<AutoSafetyCheckRequest>();

			return new AutoSafetyCheckResult(AutoSafetyCheckStatus.Allow, null);
		}
	}
}
