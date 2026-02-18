using WorkerService.Shared.Contracts;

namespace WorkerService.modules.Payments.DTOs
{
	public record AuthorizingRequestInfo(string OrderId, string CustomerId, decimal Amount, string Currency) 
	{
	}
}