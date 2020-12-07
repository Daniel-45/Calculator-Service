using CalculatorService.Client.Utilities;

namespace CalculatorService.Client
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var menu = new OptionMenu();

			menu.ShowOptionMenu();
		}
	}
}