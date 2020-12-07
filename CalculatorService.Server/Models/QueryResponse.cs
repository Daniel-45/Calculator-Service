using System.Collections.Generic;

namespace CalculatorService.Server.Models
{
	public class QueryResponse
	{
		public List<Operation> Operations { get; set; }
	}
}