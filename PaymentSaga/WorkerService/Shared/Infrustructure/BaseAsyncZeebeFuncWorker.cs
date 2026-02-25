using Grpc.Core;
using WorkerService.Shared.Contracts;
using Zeebe.Client.Accelerator.Abstractions;
using Zeebe.Client.Api.Responses;

namespace WorkerService.Shared.Infrustructure
{
	public abstract class BaseAsyncZeebeFuncWorker<TBusinessKeyModel, TZeebeJob, TResult>
		where TBusinessKeyModel : IBusinessKey, new()
		where TZeebeJob : ZeebeJob
		where TResult : class
	{
		private readonly ILogger _logger;

		protected BaseAsyncZeebeFuncWorker(ILogger logger) => _logger = logger;


		public async Task<TResult> HandleJob(TZeebeJob job, CancellationToken cancellationToken)
		{
			using var technicalLoggerScope = _logger.BeginScope(
				new Dictionary<string, object>
				{
					["JobKey"] = job.Key,
					["Executor"] = GetType().Name
				});

			var businessKey = InitializeBusinessKeyWithLogging(job);

			using var businessLoggerScope = _logger.BeginScope(
				new Dictionary<string, object>
				{
					[businessKey.Name] = businessKey.Value,
				});

			return await ExecuteWithLogging(job, cancellationToken);
		}

		protected abstract Task<TResult> HandleJobInnerFunction(TZeebeJob job, CancellationToken cancellationToken);

		private IBusinessKey InitializeBusinessKeyWithLogging(TZeebeJob job)
		{
			try
			{
				var businessKey = job.getVariables<TBusinessKeyModel>();
				ArgumentException.ThrowIfNullOrWhiteSpace(businessKey.Name);
				ArgumentException.ThrowIfNullOrWhiteSpace(businessKey.Value);

				return businessKey;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"Failed to initialize business key");
				throw;
			}
		}

		private async Task<TResult> ExecuteWithLogging(TZeebeJob job, CancellationToken ct)
		{
			try
			{
				_logger.LogInformation($">>> [START]");

				var result =  await HandleJobInnerFunction(job, ct);

				_logger.LogInformation($"<<< [SUCCESS]");

				return result;
			}
			catch (BpmnErrorException ex)
			{
				_logger.LogError(ex, $"<<< [BUSINESS-FAIL]");
				throw;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"<<< [FAIL]");
				throw;
			}
		}
	}
}
