using System.Text.Json.Serialization;

namespace WorkerService.Shared.Contracts
{
	[JsonConverter(typeof(JsonStringEnumConverter))]

	public enum FundsCapturingStatus { Success, Failed };
}
