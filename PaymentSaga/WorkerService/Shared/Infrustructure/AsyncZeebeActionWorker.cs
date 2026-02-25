using WorkerService.Shared.Contracts;
using Zeebe.Client.Accelerator.Abstractions;

namespace WorkerService.Shared.Infrustructure
{
	public abstract class AsyncZeebeActionWorker<TBusinessKeyModel, TIn> :
			BaseAsyncZeebeActionWorker<TBusinessKeyModel, ZeebeJob<TIn>>,
			IAsyncZeebeWorker<TIn>
		where TIn : class, new()
		where TBusinessKeyModel : IBusinessKey, new()
	{
		protected AsyncZeebeActionWorker(ILogger logger) : base(logger)
		{
		}

		async Task IAsyncZeebeWorker<TIn>.HandleJob(ZeebeJob<TIn> job, CancellationToken cancellationToken)
		{
			await HandleJobAction(job, cancellationToken);
		}
	}

	public abstract class AsyncZeebeActionWorker<TBusinessKeyModel> : 
			BaseAsyncZeebeActionWorker<TBusinessKeyModel, ZeebeJob>, 
			IAsyncZeebeWorker
		where TBusinessKeyModel : IBusinessKey, new()
	{
		protected AsyncZeebeActionWorker(ILogger logger) : base(logger)
		{
		}

		async Task IAsyncZeebeWorker.HandleJob(ZeebeJob job, CancellationToken cancellationToken)
		{
			await HandleJobAction(job, cancellationToken);
		}
	}
}
