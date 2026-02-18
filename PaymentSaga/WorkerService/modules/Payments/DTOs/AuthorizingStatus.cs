using System.Text.Json.Serialization;

namespace WorkerService.modules.Payments.DTOs
{
	[JsonConverter(typeof(JsonStringEnumConverter))]

	public enum AuthorizingStatus { Success, InsufficientFunds, AccountBlocked };
}
