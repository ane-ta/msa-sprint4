using Zeebe.Client.Accelerator.Abstractions;
using Zeebe.Client.Accelerator.Attributes;
using Zeebe.Client.Api.Responses;
using Zeebe.Client.Api.Worker;

namespace WorkerService
{
	public class PaymentRequestInfo
	{
		public string UserId { get; set; }
		public string OrderId { get; set; }

	}

	public class PaymentResultInfo
	{
		public string PaymentStatus { get; set; }
	}

	[JobType("Authorizing")]
	public class PaymentWorker : IAsyncZeebeWorker<PaymentRequestInfo, PaymentResultInfo>
	{
		private readonly ILogger<PaymentWorker> _logger;

		public PaymentWorker(ILogger<PaymentWorker> logger)
		{
			_logger = logger;
		}

		public async Task<PaymentResultInfo> HandleJob(ZeebeJob<PaymentRequestInfo> job, CancellationToken cancellationToken)
		{
			_logger.LogInformation("[{JobKey}] Бронирование средств...", job.Key);

			await Task.Delay(500);

			return new PaymentResultInfo
				{
					PaymentStatus = "success"
				};
		}
	}
}
