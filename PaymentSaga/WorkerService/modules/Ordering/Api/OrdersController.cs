using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WorkerService.modules.Ordering.Contracts;
using Zeebe.Client;

namespace WorkerService.modules.Ordering.Api
{
	[ApiController]
	[Route("api/orders")] 
	public class OrdersController : ControllerBase
	{
		private readonly IZeebeClient _zeebeClient;
		private readonly string _processId;

		public OrdersController(IZeebeClient zeebeClient, IConfiguration configuration)
		{
			_zeebeClient = zeebeClient;
			_processId = configuration["Zeebe:ProcessIds:Ordering"]!;
			ArgumentNullException.ThrowIfNullOrEmpty(_processId, nameof(_processId));
		}

		[HttpPost]
		public async Task<IActionResult> StartPayment([FromBody]CreateOrderRequest request)
		{
			// 1. Формируем стартовые переменные процесса
			var startVariables = new
			{
				orderId = Guid.NewGuid().ToString(),
				amount = request.info.Amount,
				customerId = request.info.CustomerId,
				currency = request.info.Currency,
				traceId = HttpContext.TraceIdentifier // Полезно для логов
			};

			// 2. Отправляем команду в Zeebe
			var result = await _zeebeClient.NewCreateProcessInstanceCommand()
				.BpmnProcessId(_processId) // ID из вашей BPMN схемы
				.LatestVersion()
				.Variables(JsonSerializer.Serialize(startVariables))
				.Send();

			// 3. Возвращаем ID процесса клиенту
			return Ok(new
			{
				ProcessInstanceKey = result.ProcessInstanceKey,
				OrderId = startVariables.orderId
			});
		}

	}
}
