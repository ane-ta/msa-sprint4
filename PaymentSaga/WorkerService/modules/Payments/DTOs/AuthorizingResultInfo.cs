namespace WorkerService.modules.Payments.DTOs
{
	public record AuthorizingResultInfo(AuthorizingStatus Status, bool FundsReserved, string? ReservationId)
	{
	}
}
