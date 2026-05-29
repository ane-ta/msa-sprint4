namespace WorkerService.Shared.Contracts
{
	public record OrderPaymentInfo() : IOrderPaymentInfo
	{
		public required string OrderId { get; init; }
		public required string CustomerId { get; init; }

		public required decimal Amount { get; init; }
		public required string Currency { get; init; }
	}
}
