using System.Text.Json;
using Zeebe.Client;
using Zeebe.Client.Api.Responses;
using Zeebe.Client.Api.Worker;

namespace WorkerService.EntryPoint
{

	public class Worker : BackgroundService
    {
//		private readonly IZeebeClient _zeebeClient;
        private readonly ILogger<Worker> _logger;
		private readonly List<IJobWorker> _workers = new();

		public Worker(/*IZeebeClient zeebeClient, */ILogger<Worker> logger)
		{
			//_zeebeClient = zeebeClient;
			_logger = logger;
		}

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			//RegisterWorkers();

			try
			{
				await Task.Delay(Timeout.Infinite, stoppingToken);
			}
			finally
			{
				DisposeWorkers();
			}
		}

		private void DisposeWorkers()
		{
			_logger.LogInformation("Остановка воркеров...");

			_workers.ForEach(w => w.Dispose());
		}

		private void RegisterWorkers()
		{
			_logger.LogInformation("Инициализация воркеров Zeebe...");

			// 1. Бронирование средств
			_workers.Add(CreateWorker("reserve-funds", HandleReserveFunds));

			// 2. Автоматическая проверка безопасности
			_workers.Add(CreateWorker("auto-security-check", HandleSecurityCheck));

			// 3. Перевод денег продавцу (финальный успешный шаг)
			_workers.Add(CreateWorker("payout-seller", HandlePayout));

			// 4. Отмена / Разблокировка (компенсация)
			_workers.Add(CreateWorker("cancel-reservation", HandleCancelation));

			_logger.LogInformation("Все воркеры запущены. Ожидание задач...");
		}

		private IJobWorker CreateWorker(string jobType, JobHandler handler)
		{
			return null;
			//return _zeebeClient.NewWorker()
			//	.JobType(jobType)
			//	.Handler(handler)
			//	.MaxJobsActive(5)
			//	.AutoCompletion() // Сам завершит задачу, если не было исключений
			//	.Open();
		}

		private async void HandleReserveFunds(IJobClient client, IJob job)
		{
			_logger.LogInformation("[{JobKey}] Бронирование средств...", job.Key);
			// Здесь могла бы быть логика списания. 
			// Если денег нет, можно вызвать client.NewThrowErrorCommand(...)
			await Task.Delay(500);
		}

		private async void HandleSecurityCheck(IJobClient client, IJob job)
		{
			_logger.LogInformation("[{JobKey}] Проверка безопасности...", job.Key);

			// Передаем переменную 'isApproved', которую ждет шлюз в BPMN
			var result = new { isApproved = true };
			var jsonVariables = JsonSerializer.Serialize(result);

			// Перезаписываем переменные в процессе при завершении
			await client.NewCompleteJobCommand(job.Key)
				.Variables(jsonVariables)
				.Send();
		}

		private async void HandlePayout(IJobClient client, IJob job)
		{
			_logger.LogInformation("[{JobKey}] Перевод денег продавцу. Успех!", job.Key);
			await Task.Delay(500);
		}

		private async void HandleCancelation(IJobClient client, IJob job)
		{
			_logger.LogWarning("[{JobKey}] Отмена транзакции и разблокировка средств.", job.Key);
			await Task.Delay(500);
		}
	}
}
