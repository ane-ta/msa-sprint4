namespace WorkerService.modules.Payments.DTOs
{
	public record FundsCapturingRequestInfo(string OrderId, string ReservationId)
	{
	}
}
