namespace WorkerService.Authorizing
{
	public class AuthorizingResultInfo
	{
		public ReservationStatus Status { get; set; }

		public string? ReservationId { get; set; }

		public bool FundsReserved { get; set; }

	}
}
