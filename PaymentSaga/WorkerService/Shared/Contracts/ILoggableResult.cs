namespace WorkerService.modules.Security.DTOs
{
	public interface ILoggableResult
	{
		object ToLogSummary()
		{
			return this;
		}
	}
}
