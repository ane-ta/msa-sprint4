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

namespace WorkerService.modules.Security.Workers
{
	[JobType("AutoSafetyCheck")]
	internal class AutoSafetyCheckWorker : AsyncZeebeFuncWorker<OrderPaymentBusinessKey, AutoSafetyCheckResult>
	{
		private static readonly Random _random = new Random();
		private readonly ILogger<AutoSafetyCheckWorker> _logger;

		public AutoSafetyCheckWorker(ILogger<AutoSafetyCheckWorker> logger): base(logger)
		{
			_logger = logger;
		}

		protected override Task<AutoSafetyCheckResult> HandleJobInnerFunction(ZeebeJob job, CancellationToken cancellationToken)
		{
			int chance = _random.Next(1, 101); // 1 - 100

			var result = chance switch
			{
				<= 40 => new AutoSafetyCheckResult(SafetyAutoCheckStatus.Allow, null),
				<= 80 => new AutoSafetyCheckResult(SafetyAutoCheckStatus.Block, "Something is suspicious"),
				_ => new AutoSafetyCheckResult(SafetyAutoCheckStatus.ManualReviewRequired, "Something is ambiguous"),
			}; 
			
			return Task.FromResult(result);
		}
	}
}
