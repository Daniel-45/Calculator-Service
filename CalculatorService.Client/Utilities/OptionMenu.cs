using System;

namespace CalculatorService.Client.Utilities
{
    public class OptionMenu
    {
        public void ShowOptionMenu()
        {
            int option;
            do
            {
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.WriteLine("\nEnter an option: 1.Add | 2.Subtract | 3.Multiply | 4.Divide | 5.Square Root | 6.Query | 7.Exit");

                option = CalculatorService.ReadInt("option");

                switch (option)
                {
                    case 1:
                        Console.WriteLine("\nYou have selected add");
                        CalculatorService.Add();
                        break;
                    case 2:
                        Console.WriteLine("\nYou have selected subtract");
                        CalculatorService.Subtract();
                        break;
                    case 3:
                        Console.WriteLine("\nYou have selected multiply");
                        CalculatorService.Multiply();
                        break;
                    case 4:
                        Console.WriteLine("\nYou have selected divide");
                        CalculatorService.Divide();
                        break;
                    case 5:
                        Console.WriteLine("\nYou have selected square root");
                        CalculatorService.SquareRoot();
                        break;
                    case 6:
                        Console.WriteLine("\nRequest all operations for a Tracking-Id since the last application restart");
                        CalculatorService.Query();
                        break;
                    case 7:
                        Console.WriteLine("\nYou have left the application\n");
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("\nPlease enter a valid option");
                        break;
                }

            } while (option != 7);

        }
    }
}
