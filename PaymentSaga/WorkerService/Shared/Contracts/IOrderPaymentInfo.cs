using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerService.Shared.Contracts
{

	public interface IOrderPaymentInfo 
	{
		string OrderId { get; }
		string CustomerId { get; }

		decimal Amount { get; }
		string Currency { get;  }
	}
}
