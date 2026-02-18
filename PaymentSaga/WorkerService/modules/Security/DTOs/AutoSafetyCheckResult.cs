namespace WorkerService.modules.Security.DTOs
{
	public record AutoSafetyCheckResult(AutoSafetyCheckStatus Decision, string? Message)
	{
	}
}
