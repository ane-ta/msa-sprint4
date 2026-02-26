using WorkerService.modules.Security.DTOs;

namespace WorkerService.Shared.Contracts
{
	public record FundsCapturingResultInfo(FundsCapturingStatus FundsCapturingResult, string? FundsCapturingMessage) : ILoggableResult
	{
	}
}