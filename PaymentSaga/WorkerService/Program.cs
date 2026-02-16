using Zeebe.Client;

namespace WorkerService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);

			builder.Services.AddSingleton<IZeebeClient>(sp =>
			{
				var config = sp.GetRequiredService<IConfiguration>();
				var gatewayAddress = config["Zeebe:GatewayAddress"];
				ArgumentNullException.ThrowIfNullOrEmpty(gatewayAddress);

				return ZeebeClient.Builder()
					.UseGatewayAddress(gatewayAddress)
					.UsePlainText()
					.Build();
			});

			builder.Services.AddHostedService<Worker>();

			var host = builder.Build();
            host.Run();
        }
    }
}