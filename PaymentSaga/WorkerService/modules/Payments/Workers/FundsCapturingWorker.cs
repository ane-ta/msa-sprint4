using WorkerService.modules.Payments.DTOs;
using Zeebe.Client.Accelerator.Abstractions;
using Zeebe.Client.Accelerator.Attributes;

namespace WorkerService.modules.Payments.Workers
{
	[JobType("FundsCapturing")]
	public class FundsCapturingWorker : IAsyncZeebeWorkerWithResult<FundsCapturingResultInfo>
	{
		private readonly ILogger<FundsCapturingWorker> _logger;

		public FundsCapturingWorker(ILogger<FundsCapturingWorker> logger)
		{
			_logger = logger;
		}

		public async Task<FundsCapturingResultInfo> HandleJob(ZeebeJob job, CancellationToken cancellationToken)
		{
			_logger.LogInformation("[{JobKey}] Authorizing payment...", job.Key);

			var info = job.getVariables<FundsCapturingRequestInfo>();

			return new FundsCapturingResultInfo(FundsCapturingStatus.Success, $"Reservation for Order {info.OrderId} released");
		}
	}
}
