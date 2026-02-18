using WorkerService.modules.Payments.DTOs;
using Zeebe.Client.Accelerator.Abstractions;
using Zeebe.Client.Accelerator.Attributes;

namespace WorkerService.modules.Payments.Workers
{
	[JobType("FundsReleasing")]
	public class FundsReleasingWorker : IAsyncZeebeWorkerWithResult<FundsReleasingResultInfo>
	{
		private readonly ILogger<FundsReleasingWorker> _logger;

		public FundsReleasingWorker(ILogger<FundsReleasingWorker> logger)
		{
			_logger = logger;
		}

		public async Task<FundsReleasingResultInfo> HandleJob(ZeebeJob job, CancellationToken cancellationToken)
		{
			_logger.LogInformation("[{JobKey}] Releasing payment...", job.Key);

			var info = job.getVariables<FundsReleasingRequestInfo>();

			return new FundsReleasingResultInfo(FundsReleasingStatus.Success, $"Funds are released");
		}
	}
}
