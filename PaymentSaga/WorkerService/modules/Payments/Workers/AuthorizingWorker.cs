using Microsoft.AspNetCore.Authorization;
using WorkerService.Shared.Contracts;
using Zeebe.Client.Accelerator.Abstractions;
using Zeebe.Client.Accelerator.Attributes;

namespace WorkerService.modules.Payments.Workers
{
	[JobType("Authorizing")]
	public class AuthorizingWorker : IAsyncZeebeWorkerWithResult<FundsAuthorizingResultInfo>
	{
		private readonly ILogger<AuthorizingWorker> _logger;

		public AuthorizingWorker(ILogger<AuthorizingWorker> logger)
		{
			_logger = logger;
		}

		public async Task<FundsAuthorizingResultInfo> HandleJob(ZeebeJob job, CancellationToken cancellationToken)
		{
			_logger.LogInformation("[{JobKey}] Authorizing payment...", job.Key);

			var info = job.getVariables<OrderPaymentInfo>();

			var random = new Random();
			int chance = random.Next(1, 101); // 1 - 100

			var result = chance switch
			{
				<= 50 => new FundsAuthorizingResultInfo( FundsAuthorizingStatus.Success, true, Guid.NewGuid().ToString()),
				_ => new FundsAuthorizingResultInfo(FundsAuthorizingStatus.InsufficientFunds, false, null),
			};

			return result;
		}
	}
}
