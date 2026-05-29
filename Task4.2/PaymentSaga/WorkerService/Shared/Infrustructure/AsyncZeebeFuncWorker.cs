using WorkerService.Shared.Contracts;
using Zeebe.Client.Accelerator.Abstractions;

namespace WorkerService.Shared.Infrustructure
{
	public abstract class AsyncZeebeFuncWorker<TBusinessKeyModel, TIn, TOut> : 
			BaseAsyncZeebeFuncWorker<TBusinessKeyModel, ZeebeJob<TIn>, TOut>, 
			IAsyncZeebeWorker<TIn, TOut>
		where TBusinessKeyModel : IBusinessKey, new()
		where TIn : class, new()
		where TOut : class
	{
		protected AsyncZeebeFuncWorker(ILogger logger) : base(logger)
		{
		}
	}

	public abstract class AsyncZeebeFuncWorker<TBusinessKeyModel,TOut> :
		BaseAsyncZeebeFuncWorker<TBusinessKeyModel, ZeebeJob, TOut>,
		IAsyncZeebeWorkerWithResult<TOut>
	where TBusinessKeyModel : IBusinessKey, new()
	where TOut : class
	{
		protected AsyncZeebeFuncWorker(ILogger logger) : base(logger)
		{
		}
	}
}
