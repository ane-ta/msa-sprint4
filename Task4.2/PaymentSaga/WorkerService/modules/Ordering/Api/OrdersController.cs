using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WorkerService.modules.Ordering.Contracts;
using WorkerService.Shared.Contracts;
using Zeebe.Client;
using Zeebe.Client.Accelerator.Extensions;

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
			var orderInfo = new OrderPaymentInfo()
			{
				OrderId = Guid.NewGuid().ToString(),
				CustomerId = request.info.CustomerId,
				Amount = request.info.Amount,
				Currency = request.info.Currency,
			};
			var traceInfo = new
			{
				TraceId = HttpContext.TraceIdentifier // Полезно для логов
			};

			// 2. Отправляем команду в Zeebe
			var result = await _zeebeClient.NewCreateProcessInstanceCommand()
				.BpmnProcessId(_processId) // ID из вашей BPMN схемы
				.LatestVersion()
				.State(new { 
					orderInfo.OrderId,
					orderInfo.CustomerId,
					orderInfo.Amount,
					orderInfo.Currency,

					traceInfo.TraceId,
				})
				.Send();

			return Ok(new
			{
				ProcessInstanceKey = result.ProcessInstanceKey,
				OrderId = orderInfo.OrderId
			});
		}

	}
}
