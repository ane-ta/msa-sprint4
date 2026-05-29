using WorkerService.Shared.Contracts;
using Zeebe.Client.Accelerator.Abstractions;

namespace WorkerService.Shared.Infrustructure
{
	public abstract class BaseAsyncZeebeActionWorker<TBusinessKeyModel, TZeebeJob> : 
			BaseAsyncZeebeFuncWorker<TBusinessKeyModel, TZeebeJob, Unit>
		where TBusinessKeyModel : IBusinessKey, new()
		where TZeebeJob : ZeebeJob
	{
		public BaseAsyncZeebeActionWorker(ILogger logger) : base(logger)
		{
		}
		protected sealed override async Task<Unit> HandleJobInnerFunction(TZeebeJob job, CancellationToken cancellationToken)
		{
			await HandleJobInnerAction(job, cancellationToken);

			return Unit.Value;
		}

		protected async Task HandleJobAction(TZeebeJob job, CancellationToken cancellationToken)
		{
			await base.HandleJob(job, cancellationToken);
		}
		protected abstract Task HandleJobInnerAction(ZeebeJob job, CancellationToken cancellationToken);
	}
}
