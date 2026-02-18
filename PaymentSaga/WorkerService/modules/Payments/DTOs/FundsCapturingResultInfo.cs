namespace WorkerService.modules.Payments.DTOs
{
	public record FundsCapturingResultInfo(FundsCapturingStatus Status, string? Message)
	{
	}
}
