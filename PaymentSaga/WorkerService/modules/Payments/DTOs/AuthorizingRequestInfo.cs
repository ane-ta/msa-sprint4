namespace WorkerService.modules.Payments.DTOs
{
	public class AuthorizingRequestInfo
	{
		public string? OrderId { get; set; }
		public string? CustomerId { get; set; }

		public decimal Amount { get; set; }
		public string? Currency { get; set; }
	}
}
