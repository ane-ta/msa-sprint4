using WorkerService.modules.Payments.DTOs;
using WorkerService.Shared.Contracts;
using WorkerService.Shared.Infrustructure;
using Zeebe.Client.Accelerator.Abstractions;
using Zeebe.Client.Accelerator.Attributes;

namespace WorkerService.modules.Payments.Workers
{
	[JobType("FundsCapturing")]
	public class FundsCapturingWorker : AsyncZeebeFuncWorker<OrderPaymentBusinessKey, FundsCapturingResultInfo>
	{
		private readonly ILogger<FundsCapturingWorker> _logger;

		public FundsCapturingWorker(ILogger<FundsCapturingWorker> logger) : base(logger)
		{
			_logger = logger;
		}

		protected override Task<FundsCapturingResultInfo> HandleJobInnerFunction(ZeebeJob job, CancellationToken cancellationToken)
		{
			return Task.FromResult(new FundsCapturingResultInfo(FundsCapturingStatus.Success, $"Funds captured"));
		}
	}
}
