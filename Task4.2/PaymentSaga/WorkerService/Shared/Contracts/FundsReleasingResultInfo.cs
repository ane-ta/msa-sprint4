using WorkerService.modules.Security.DTOs;

namespace WorkerService.modules.Payments.DTOs
{
	public record FundsReleasingResultInfo(FundsReleasingStatus FundsReleasingResult, string? FundsReleasingMessage) : ILoggableResult
	{
	}
}
