namespace WorkerService.Authorizing
{
	public class AuthorizingRequestInfo
	{
		public string? OrderId { get; set; }
		public string? CustomerId { get; set; }

		public decimal Amount { get; set; }
		public string? Currency { get; set; }
	}
}
