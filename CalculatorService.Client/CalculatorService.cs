using System;
using RestSharp;
using Newtonsoft.Json;
using CalculatorService.Client.Models;
using CalculatorService.Client.Exceptions;

namespace CalculatorService.Client
{
    class CalculatorService
    {
        private static string ENDPOINT = "http://localhost:54405/api/calculator/";

        #region Request add operation
        public static void Add()
        {
            int number, howMany;

            try
            {
                AddRequest add = new AddRequest();

                string id = AskTrackingId();

                Console.WriteLine("\nHow many numbers do you want to add?");

                do
                {
                    howMany = ReadInt("to know the amount of numbers to add");

                    if (howMany < 2)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;

                        Console.WriteLine("\nAt least two numbers are needed for the addition operation");

                        Console.ForegroundColor = ConsoleColor.Gray;

                        Console.WriteLine("\nHow many numbers do you want to add?");
                    }

                } while (howMany < 2);

                add.Addens = new int[howMany];

                for (int i = 0; i < add.Addens.Length; i++)
                {
                    Console.WriteLine("\nEnter a number:");

                    number = ReadInt("add");

                    add.Addens[i] = number;
                }

                var client = new RestClient(ENDPOINT);

                var request = new RestRequest("add", Method.POST);

                string json = JsonConvert.SerializeObject(add);

                request.AddJsonBody(json);

                // Add to headers 'X-Evi-Tracking-Id'
                if (id != "")
                {
                    request.AddHeader("X-Evi-Tracking-Id", id);
                }

                var response = client.Execute(request);

                var proccessResponse = JsonConvert.DeserializeObject<AddResponse>(response.Content);

                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("\nResult: " + proccessResponse.Sum);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public static void TestAdd()
        {
            AddRequest add = new AddRequest();

            add.Addens = new int[] { 2, 2, 3 };

            var client = new RestClient(ENDPOINT);

            var request = new RestRequest("add", Method.POST);

            string json = JsonConvert.SerializeObject(add);

            request.AddJsonBody(json);

            var response = client.Execute(request);

            var proccessResponse = JsonConvert.DeserializeObject<AddResponse>(response.Content);

            Console.WriteLine("\nResult: " + proccessResponse.Sum);

        }
        #endregion

        #region Request substract operation
        public static void Subtract()
        {
            int minuend, substrahend;

            try
            {
                SubtractRequest sub = new SubtractRequest();

                string id = AskTrackingId();

                Console.WriteLine("\nEnter minuend and substrahend");

                Console.WriteLine("\nEnter minuend:");

                minuend = ReadInt("the minuend");

                sub.Minuend = minuend;

                Console.WriteLine("\nEnter substrahend:");

                substrahend = ReadInt("substrahend");

                sub.Subtrahend = substrahend;

                var client = new RestClient(ENDPOINT);

                var request = new RestRequest("sub", Method.POST);

                string json = JsonConvert.SerializeObject(sub);

                request.AddJsonBody(json);

                // Add to headers 'X-Evi-Tracking-Id'
                if (id != "")
                {
                    request.AddHeader("X-Evi-Tracking-Id", id);
                }

                var response = client.Execute(request);

                var proccessResponse = JsonConvert.DeserializeObject<SubtractResponse>(response.Content);

                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("\nResult: " + proccessResponse.Difference);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public static void TestSubtract()
        {
            SubtractRequest sub = new SubtractRequest();

            sub.Minuend = 11;

            sub.Subtrahend = 5;

            var client = new RestClient(ENDPOINT);

            var request = new RestRequest("sub", Method.POST);

            string json = JsonConvert.SerializeObject(sub);

            request.AddJsonBody(json);

            var response = client.Execute(request);

            var proccessResponse = JsonConvert.DeserializeObject<SubtractResponse>(response.Content);

            Console.WriteLine("\nResult: " + proccessResponse.Difference);
        }
        #endregion

        #region Request multiply operation
        public static void Multiply()
        {
            int number, howMany;

            try
            {
                MultiplyRequest mult = new MultiplyRequest();

                string id = AskTrackingId();

                Console.WriteLine("\nHow many numbers do you want to multiply?");

                do
                {
                    howMany = ReadInt("the amount of numbers to multiply");

                    if (howMany < 2)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;

                        Console.WriteLine("\nAt least two numbers are needed for the multiplication operation");

                        Console.ForegroundColor = ConsoleColor.Gray;

                        Console.WriteLine("\nHow many numbers do you want to multiply?");
                    }

                } while (howMany < 2);

                mult.Factors = new int[howMany];

                for (int i = 0; i < mult.Factors.Length; i++)
                {
                    Console.WriteLine("\nEnter a number:");

                    number = ReadInt("number to multiply");

                    mult.Factors[i] = number;
                }

                var client = new RestClient(ENDPOINT);

                var request = new RestRequest("mult", Method.POST);

                string json = JsonConvert.SerializeObject(mult);

                request.AddJsonBody(json);

                // Add to headers 'X-Evi-Tracking-Id'
                if (id != "")
                {
                    request.AddHeader("X-Evi-Tracking-Id", id);
                }

                var response = client.Execute(request);

                var proccessResponse = JsonConvert.DeserializeObject<MultiplyResponse>(response.Content);

                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("\nResult: " + proccessResponse.Product);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public static void TestMultiply()
        {
            MultiplyRequest mult = new MultiplyRequest();

            mult.Factors = new int[] { 8, 3, 2 };

            var client = new RestClient(ENDPOINT);

            var request = new RestRequest("mult", Method.POST);

            string json = JsonConvert.SerializeObject(mult);

            request.AddJsonBody(json);

            var response = client.Execute(request);

            var proccessResponse = JsonConvert.DeserializeObject<MultiplyResponse>(response.Content);

            Console.WriteLine("\nResult: " + proccessResponse.Product);
        }
        #endregion

        #region Request divide operation
        public static void Divide()
        {
            int dividend, divisor;

            try
            {

                DivideRequest div = new DivideRequest();

                string id = AskTrackingId();

                Console.WriteLine("\nEnter dividend and divisor");

                Console.WriteLine("\nEnter dividend:");

                dividend = ReadInt("dividend");

                div.Dividend = dividend;

                Console.WriteLine("\nEnter divisor: ");

                divisor = ReadInt("divisor");

                div.Divisor = divisor;

                var client = new RestClient(ENDPOINT);

                var request = new RestRequest("div", Method.POST);

                string json = JsonConvert.SerializeObject(div);

                request.AddJsonBody(json);

                // Add to headers 'X-Evi-Tracking-Id'
                if (id != "")
                {
                    request.AddHeader("X-Evi-Tracking-Id", id);
                }

                var response = client.Execute(request);

                var proccessResponse = JsonConvert.DeserializeObject<DivideResponse>(response.Content);

                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("\nQuotient: " + proccessResponse.Quotient);

                Console.WriteLine("\nRemainder: " + proccessResponse.Remainder);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public static void TestDivide()
        {
            DivideRequest div = new DivideRequest();

            div.Dividend = 11;

            div.Divisor = 2;

            var client = new RestClient(ENDPOINT);

            var request = new RestRequest("div", Method.POST);

            string json = JsonConvert.SerializeObject(div);

            request.AddJsonBody(json);

            var response = client.Execute(request);

            var proccessResponse = JsonConvert.DeserializeObject<DivideResponse>(response.Content);

            Console.WriteLine("\nResult: " + proccessResponse.Quotient);

            Console.WriteLine("\nRemainder: " + proccessResponse.Remainder);
        }
        #endregion

        #region Request square root operation
        public static void SquareRoot()
        {
            try
            {
                SqrtRequest sqrt = new SqrtRequest();

                string id = AskTrackingId();

                Console.WriteLine("\nEnter a number: ");

                sqrt.Number = ReadInt("square root");

                var client = new RestClient(ENDPOINT);

                var request = new RestRequest("sqrt", Method.POST);

                string json = JsonConvert.SerializeObject(sqrt);

                request.AddJsonBody(json);

                // Add to headers 'X-Evi-Tracking-Id'
                if (id != "")
                {
                    request.AddHeader("X-Evi-Tracking-Id", id);
                }

                var response = client.Execute(request);

                var proccessResponse = JsonConvert.DeserializeObject<SqrtResponse>(response.Content);

                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("\nResult: " + proccessResponse.Square);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void TestSquareRoot()
        {
            SqrtRequest sqrt = new SqrtRequest();

            sqrt.Number = 8;

            var client = new RestClient(ENDPOINT);

            var request = new RestRequest("sqrt", Method.POST);

            string json = JsonConvert.SerializeObject(sqrt);

            request.AddJsonBody(json);

            var response = client.Execute(request);

            var proccessResponse = JsonConvert.DeserializeObject<SqrtResponse>(response.Content);

            Console.WriteLine("\nResult: " + proccessResponse.Square);
        }
        #endregion

        #region Request all operations for a Tracking-Id
        public static void Query()
        {
            try
            {
                QueryRequest query = new QueryRequest();

                Console.WriteLine("\nEnter an id:");

                Console.Write("\n>> ");

                string id = Console.ReadLine();

                query.Id = id;

                var client = new RestClient(ENDPOINT);

                var request = new RestRequest("query", Method.POST);

                string json = JsonConvert.SerializeObject(query);

                request.AddJsonBody(json);

                var response = client.Execute(request);

                var proccessResponse = JsonConvert.DeserializeObject<QueryResponse>(response.Content);

                // Show the list of operations associated with an id
                foreach (var operation in proccessResponse.Operations)
                {
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine(string.Format($"\nOperation: {operation.Name} Calculation: {operation.Calculation} Date: {operation.Date}"));
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("\nThe request could not be processed. There isn't operations for the id.\n");

                Console.WriteLine(ex.Message);
            }
        }
        #endregion

        #region Utilities
        // Function to validate and read an integer
        public static int ReadInt(string message)
        {
            int number = 0;

            var input = "";

            bool exit = false;

            do
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Gray;

                    Console.Write("\n>> ");

                    input = Console.ReadLine();

                    number = int.Parse(input);

                    exit = true;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;

                    Console.WriteLine($"\nYou have to enter a number to {message}");

                    exit = false;
                }
            } while (exit == false);

            return number;
        }

        // Function to ask user if he wants to add tracking id
        public static string AskTrackingId()
        {
            var response = "";

            var id = "";

            Console.WriteLine("\nDo you want to enter tracking id? (Y/N)");

            Console.Write("\n>> ");

            do
            {
                response = Console.ReadLine().ToLowerInvariant();

                if (!response.Equals("y") && !response.Equals("n"))
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;

                    Console.WriteLine("\nPlease enter (Y/N)");

                    Console.ForegroundColor = ConsoleColor.Gray;

                    Console.Write("\n>> ");
                }

                if (response.Equals("y"))
                {

                    Console.WriteLine("\nEnter your tracking id:");

                    Console.Write("\n>> ");

                    id = Console.ReadLine();
                }

            } while (!response.Equals("y") && !response.Equals("n"));

            return id;
        }
        #endregion
    }
}
