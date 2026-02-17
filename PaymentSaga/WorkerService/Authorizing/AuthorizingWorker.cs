using Zeebe.Client.Accelerator.Abstractions;
using Zeebe.Client.Accelerator.Attributes;
using Zeebe.Client.Api.Responses;
using Zeebe.Client.Api.Worker;

namespace WorkerService.Authorizing
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

			return new AuthorizingResultInfo
				{
					Status = ReservationStatus.SUCCESS,
					ReservationId = $"Reservation for Order {info.OrderId}",
					FundsReserved = true
				};
		}
	}
}
