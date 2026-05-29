namespace WorkerService.modules.Payments.DTOs
{
	public record FundsReleasingRequestInfo(string OrderId, string ReservationId)
	{
	}
}
