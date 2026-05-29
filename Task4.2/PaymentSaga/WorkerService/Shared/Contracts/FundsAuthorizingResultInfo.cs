using WorkerService.modules.Security.DTOs;

namespace WorkerService.Shared.Contracts
{
	public record FundsAuthorizingResultInfo(FundsAuthorizingStatus FundsAuthorizingResult, bool FundsAuthorized, string? FundsAuthorizingId) : ILoggableResult
	{
	}
}
