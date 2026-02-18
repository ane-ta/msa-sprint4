namespace WorkerService.Shared.Contracts
{
	public record OrderPaymentInfo(string OrderId, string CustomerId, decimal Amount, string Currency) : IOrderPaymentInfo
	{
	}

}
