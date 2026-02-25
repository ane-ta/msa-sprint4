using WorkerService.modules.Payments.DTOs;
using WorkerService.Shared.Contracts;
using WorkerService.Shared.Infrustructure;
using Zeebe.Client.Accelerator.Abstractions;
using Zeebe.Client.Accelerator.Attributes;

namespace WorkerService.modules.Payments.Workers
{
	[JobType("FundsReleasing")]
	public class FundsReleasingWorker : AsyncZeebeFuncWorker<OrderPaymentBusinessKey, FundsReleasingResultInfo>
	{
		private readonly ILogger<FundsReleasingWorker> _logger;

		public FundsReleasingWorker(ILogger<FundsReleasingWorker> logger) : base(logger)
		{
			_logger = logger;
		}

		protected override Task<FundsReleasingResultInfo> HandleJobInnerFunction(ZeebeJob job, CancellationToken cancellationToken)
		{
			return Task.FromResult(new FundsReleasingResultInfo(FundsReleasingStatus.Success, $"Funds are released"));
		}
	}
}
