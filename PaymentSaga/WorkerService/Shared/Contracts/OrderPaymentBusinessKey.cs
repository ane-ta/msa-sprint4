namespace WorkerService.Shared.Contracts
{
	public class OrderPaymentBusinessKey : IBusinessKey
	{
		public string Name => "OrderId";

		public string Value => OrderId;

		public string OrderId { get; init; } = default!;

	}
}
