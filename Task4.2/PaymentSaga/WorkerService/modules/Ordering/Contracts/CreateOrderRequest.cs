using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerService.Shared.Contracts;

namespace WorkerService.modules.Ordering.Contracts
{
	public record CreateOrderRequest(OrderPaymentInfo info)
	{
	}
}
