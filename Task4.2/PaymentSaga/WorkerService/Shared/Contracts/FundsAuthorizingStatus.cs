using System.Text.Json.Serialization;

namespace WorkerService.Shared.Contracts
{
	[JsonConverter(typeof(JsonStringEnumConverter))]

	public enum FundsAuthorizingStatus { Success, InsufficientFunds, AccountBlocked };
}
