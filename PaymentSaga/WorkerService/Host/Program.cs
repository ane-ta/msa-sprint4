using Zeebe.Client;
using Zeebe.Client.Accelerator.Extensions;

namespace WorkerService.EntryPoint
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);

			builder.Services.BootstrapZeebe(
				builder.Configuration.GetSection("Zeebe"),
				typeof(Program).Assembly);

			builder.Services.AddHostedService<Worker>();

			var host = builder.Build();
            host.Run();
        }
    }
}