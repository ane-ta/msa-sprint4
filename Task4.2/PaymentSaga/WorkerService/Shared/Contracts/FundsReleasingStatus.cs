using System.Text.Json.Serialization;

namespace WorkerService.modules.Payments.DTOs
{
	[JsonConverter(typeof(JsonStringEnumConverter))]

	public enum FundsReleasingStatus { Success, Failed };
}
