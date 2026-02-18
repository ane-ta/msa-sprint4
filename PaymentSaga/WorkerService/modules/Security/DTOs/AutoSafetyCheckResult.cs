namespace WorkerService.modules.Security.DTOs
{
	public record AutoSafetyCheckResult(string CheckId, AutoSafetyCheckStatus Decision, string? Message)
	{
	}
}
