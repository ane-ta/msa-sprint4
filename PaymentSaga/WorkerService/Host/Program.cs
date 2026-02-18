using Google.Protobuf.WellKnownTypes;
using System.Text.Json;
using Zeebe.Client;
using Zeebe.Client.Accelerator;
using Zeebe.Client.Accelerator.Abstractions;
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
				typeof(Program).Assembly)
			;

			builder.Services.AddSingleton<IZeebeVariablesSerializer>(sp =>
			{
				var options = new JsonSerializerOptions
				{
					PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
					PropertyNameCaseInsensitive = true
				};
				return new ZeebeVariablesSerializer(options);
			});

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