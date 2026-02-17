namespace WorkerService.modules.Payments.DTOs
{
	public class AuthorizingResultInfo
	{
		public ReservationStatus Status { get; set; }

		public string? ReservationId { get; set; }

		public bool FundsReserved { get; set; }

	}
}
