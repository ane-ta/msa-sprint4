using System.Text.Json.Serialization;

namespace WorkerService.modules.Security.DTOs
{
	[JsonConverter(typeof(JsonStringEnumConverter))]
	public enum AutoSafetyCheckStatus
	{
		Allow,
		Block,
		ManualReviewRequired
	}
}
