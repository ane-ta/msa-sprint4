using Microsoft.AspNetCore.Authorization;
using WorkerService.Shared.Contracts;
using WorkerService.Shared.Infrustructure;
using Zeebe.Client.Accelerator.Abstractions;
using Zeebe.Client.Accelerator.Attributes;

namespace WorkerService.modules.Payments.Workers
{
	[JobType("Authorizing")]
	public class AuthorizingWorker : AsyncZeebeFuncWorker<OrderPaymentBusinessKey, FundsAuthorizingResultInfo>
	{
		private static readonly Random _random = new Random(); 
		private readonly ILogger<AuthorizingWorker> _logger;

		public AuthorizingWorker(ILogger<AuthorizingWorker> logger) : base(logger)
		{
			_logger = logger;
		}

		protected override async Task<FundsAuthorizingResultInfo> HandleJobInnerFunction(ZeebeJob job, CancellationToken cancellationToken)
		{
			var info = job.getVariables<OrderPaymentInfo>();

			int chance = _random.Next(1, 101); // 1 - 100

			var result = chance switch
			{
				<= 50 => new FundsAuthorizingResultInfo(FundsAuthorizingStatus.Success, true, Guid.NewGuid().ToString()),
				_ => new FundsAuthorizingResultInfo(FundsAuthorizingStatus.InsufficientFunds, false, null),
			};

			return await Task.FromResult(result);
		}
	}
}
