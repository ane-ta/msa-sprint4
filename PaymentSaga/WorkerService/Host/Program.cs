using Google.Protobuf.WellKnownTypes;
using Zeebe.Client;
using Zeebe.Client.Accelerator.Extensions;

namespace WorkerService.EntryPoint
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

			builder.Services.BootstrapZeebe(
				builder.Configuration.GetSection("Zeebe"),
				typeof(Program).Assembly);

			builder.Services.AddHostedService<Worker>();

			builder.Services.AddControllers();
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();


			var app = builder.Build();
			app.MapControllers();
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.Run();
        }
    }
}