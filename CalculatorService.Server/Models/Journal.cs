using System.Linq;
using System.Collections.Generic;

namespace CalculatorService.Server.Models
{
	public class Journal
	{
		public static Dictionary<string, List<Operation>> Data = new Dictionary<string, List<Operation>>();

		public void Store(string id, Operation operation)
		{
			if (!Data.ContainsKey(id))
			{
				Data.Add(id, new List<Operation>());
			}

			// Find the entry in function of the entered id
			Data.Where(x => x.Key == id).FirstOrDefault().Value.Add(operation);
		}

		public List<Operation> Get(string id)
		{
			// Returns the operation lists in the key id
			if (Data.ContainsKey(id))
			{
				return Data.Where(x => x.Key == id).FirstOrDefault().Value;
			}
			else
			{
				return null;
			}
		}
	}
}
