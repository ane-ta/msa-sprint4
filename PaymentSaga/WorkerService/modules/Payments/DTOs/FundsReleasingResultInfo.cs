namespace WorkerService.modules.Payments.DTOs
{
	public record FundsReleasingResultInfo(FundsReleasingStatus Status, string? Message)
	{
	}
}
