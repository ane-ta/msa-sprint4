using WorkerService.modules.Payments.DTOs;
using Zeebe.Client.Accelerator.Abstractions;
using Zeebe.Client.Accelerator.Attributes;

namespace WorkerService.modules.Payments.Workers
{
	[JobType("Authorizing")]
	public class AuthorizingWorker : IAsyncZeebeWorkerWithResult<AuthorizingResultInfo>
	{
		private readonly ILogger<AuthorizingWorker> _logger;

		public AuthorizingWorker(ILogger<AuthorizingWorker> logger)
		{
			_logger = logger;
		}

		public async Task<AuthorizingResultInfo> HandleJob(ZeebeJob job, CancellationToken cancellationToken)
		{
			_logger.LogInformation("[{JobKey}] Authorizing payment...", job.Key);

			var info = job.getVariables<AuthorizingRequestInfo>();

			return new AuthorizingResultInfo(AuthorizingStatus.Success, true, $"Reservation for Order {info.OrderId}");
		}
	}
}
