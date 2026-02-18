using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerService.modules.Payments.DTOs;
using WorkerService.modules.Security.DTOs;
using WorkerService.Shared.Contracts;
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

			var random = new Random();
			int chance = random.Next(1, 101); // 1 - 100

			var result = chance switch
			{
				<= 40 => new AutoSafetyCheckResult(SafetyAutoCheckStatus.Allow, null),
				<= 80 => new AutoSafetyCheckResult(SafetyAutoCheckStatus.Block, "Something is suspicious"),
				_ => new AutoSafetyCheckResult(SafetyAutoCheckStatus.ManualReviewRequired, "Something is ambiguous"),
			};

			return result;
		}
	}
}
