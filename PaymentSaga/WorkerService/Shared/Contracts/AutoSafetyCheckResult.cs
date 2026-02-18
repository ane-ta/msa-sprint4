namespace WorkerService.modules.Security.DTOs
{
	public record AutoSafetyCheckResult(SafetyAutoCheckStatus SafetyAutoCheckResult, string? SafetyAutoCheckMessage)
	{
	}
}
