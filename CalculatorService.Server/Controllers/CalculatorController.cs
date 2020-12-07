using NLog;
using System;
using System.Net;
using System.Linq;
using System.Web.Http;
using System.Collections.Generic;
using CalculatorService.Server.Models;

namespace CalculatorService.Server.Controllers
{
	public class CalculatorController : ApiController
	{
		public static Journal Journal = new Journal();
		private static Logger logger = LogManager.GetCurrentClassLogger();

		[HttpPost]
		[ActionName("add")]
		public IHttpActionResult Add(AddRequest request)
		{
			logger.Trace("Service called: add");

			// An invalid request has been received
			// This may mean the HTTP requests and/or the HTTP body may contains some errors which should be fixed

			if (request.Addens == null)
			{
				logger.Error(HttpStatusCode.BadRequest);

				throw new HttpResponseException(HttpStatusCode.BadRequest);
			}

			try
			{
				AddResponse result = new AddResponse();

				// Execute operation: Add
				string dataJournal = "";

				foreach (int number in request.Addens)
				{
					result.Sum += number;

					dataJournal += number + " + ";
				}

				dataJournal = dataJournal.Substring(0, dataJournal.Length - 3);

				dataJournal += " = " + result.Sum;

				logger.Trace("Add success!!");

				IEnumerable<string> headerValues;

				// If tracking ID exists create operation instance and store in journal
				if (Request.Headers.TryGetValues("X-Evi-Tracking-Id", out headerValues))
				{
					string id;

					id = headerValues.FirstOrDefault();

					var operation = new Operation()
					{
						Name = "addition",
						Calculation = dataJournal,
						Date = DateTime.Now
					};

					Journal.Store(id, operation);
				}

				return Ok(result);
			}
			catch (Exception ex)
			{
				logger.Error(ex);

				// An unexpected error condition was triggered which made impossible to fulfill the request
				throw new HttpResponseException(HttpStatusCode.InternalServerError);
			}

		}

		[HttpPost]
		[ActionName("sub")]
		public IHttpActionResult Subtract(SubtractRequest request)
		{
			logger.Trace("Service called: subtract");

			// An invalid request has been received
			// This may mean the HTTP requests and/or the HTTP body may contains some errors which should be fixed

			if (request == null)
			{
				logger.Error(HttpStatusCode.BadRequest);

				throw new HttpResponseException(HttpStatusCode.BadRequest);
			}

			try
			{
				SubtractResponse result = new SubtractResponse();

				// Execute operation: Subtraction
				string dataJournal = "";

				result.Difference = request.Minuend - request.Subtrahend;

				dataJournal = request.Minuend + " - " + request.Subtrahend + " = " + result.Difference;

				logger.Trace("Substract success!!");

				IEnumerable<string> headerValues;

				// If tracking ID exists create operation instance and store in journal
				if (Request.Headers.TryGetValues("X-Evi-Tracking-Id", out headerValues))
				{
					string id;

					id = headerValues.FirstOrDefault();

					var operation = new Operation()
					{
						Name = "subtraction",
						Calculation = dataJournal,
						Date = DateTime.Now
					};

					Journal.Store(id, operation);
				}

				return Ok(result);
			}
			catch (Exception ex)
			{
				logger.Error(ex);

				// An unexpected error condition was triggered which made impossible to fulfill the request.
				throw new HttpResponseException(HttpStatusCode.InternalServerError);
			}

		}

		[HttpPost]
		[ActionName("mult")]
		public IHttpActionResult Multiply(MultiplyRequest request)
		{
			logger.Trace("Service called: multiply");

			// An invalid request has been received
			// This may mean the HTTP requests and/or the HTTP body may contains some errors which should be fixed

			if (request.Factors == null)
			{
				logger.Error(HttpStatusCode.BadRequest);
				throw new HttpResponseException(HttpStatusCode.BadRequest);
			}

			try
			{
				MultiplyResponse result = new MultiplyResponse();

				// Execute operation: Multiplication
				string dataJournal = "";

				foreach (int number in request.Factors)
				{
					result.Product *= number;

					dataJournal += number + " * ";
				}

				dataJournal = dataJournal.Substring(0, dataJournal.Length - 3);

				dataJournal += " = " + result.Product;

				logger.Trace("Multiply success!!");

				IEnumerable<string> headerValues;

				if (Request.Headers.TryGetValues("X-Evi-Tracking-Id", out headerValues))
				{
					string id;

					id = headerValues.FirstOrDefault();

					var operation = new Operation()
					{
						Name = "multiplication",
						Calculation = dataJournal,
						Date = DateTime.Now
					};

					Journal.Store(id, operation);
				}

				return Ok(result);
			}
			catch (Exception ex)
			{
				logger.Error(ex);

				// An unexpected error condition was triggered which made impossible to fulfill the request
				throw new HttpResponseException(HttpStatusCode.InternalServerError);
			}

		}

		[HttpPost]
		[ActionName("div")]
		public IHttpActionResult Divide(DivideRequest request)
		{
			logger.Trace("Service called: divide");

			// An invalid request has been received
			// This may mean the HTTP requests and/or the HTTP body may contains some errors which should be fixed

			if (request == null)
			{
				logger.Error(HttpStatusCode.BadRequest);

				throw new HttpResponseException(HttpStatusCode.BadRequest);
			}

			try
			{
				DivideResponse result = new DivideResponse();

				// Execute operation: Divison
				string dataJournal = "";

				result.Quotient = request.Dividend / request.Divisor;
				result.Remainder = request.Dividend % request.Divisor;

				dataJournal += request.Dividend + " / " + request.Divisor + " = " + "quotient: " + result.Quotient + " remainder: " + result.Remainder;

				logger.Trace("Divide success!!");

				IEnumerable<string> headerValues;

				// If tracking ID exists create operation instance and store in journal
				if (Request.Headers.TryGetValues("X-Evi-Tracking-Id", out headerValues))
				{
					string id;

					id = headerValues.FirstOrDefault();

					var operation = new Operation()
					{
						Name = "division",
						Calculation = dataJournal,
						Date = DateTime.Now
					};

					Journal.Store(id, operation);
				}

				return Ok(result);
			}
			catch (Exception ex)
			{
				logger.Error(ex);

				// An unexpected error condition was triggered which made impossible to fulfill the request
				throw new HttpResponseException(HttpStatusCode.InternalServerError);
			}

		}

		[HttpPost]
		[ActionName("sqrt")]
		public IHttpActionResult Square(SqrtRequest request)
		{
			string dataJournal = "";

			IEnumerable<string> headerValues;

			logger.Trace("Service called: square root");

			// An invalid request has been received
			// This may mean the HTTP requests and/or the HTTP body may contains some errors which should be fixed

			if (request == null)
			{
				logger.Error(HttpStatusCode.BadRequest);

				throw new HttpResponseException(HttpStatusCode.BadRequest);
			}

			try
			{
				SqrtResponse result = new SqrtResponse();


				// Execute operation: Square root
				result.Square = Math.Sqrt(request.Number);

				dataJournal = "√" + request.Number + " = " + result.Square;

				logger.Trace("Square success!!");

				// If tracking ID exists create operation instance and store in journal
				if (Request.Headers.TryGetValues("X-Evi-Tracking-Id", out headerValues))
				{
					string id;

					id = headerValues.FirstOrDefault();

					var operation = new Operation()
					{
						Name = "square root",
						Calculation = dataJournal,
						Date = DateTime.Now
					};

					Journal.Store(id, operation);
				}

				return Ok(result);
			}
			catch (Exception ex)
			{
				logger.Error(ex);

				// An unexpected error condition was triggered which made impossible to fulfill the request
				throw new HttpResponseException(HttpStatusCode.InternalServerError);
			}
		}

		[HttpPost]
		[ActionName("query")]
		public QueryResponse Query(QueryRequest request)
		{
			// An invalid request has been received. 
			// This may mean the HTTP requests and/or the HTTP body may contains some errors which should be fixed
			if (request == null)
			{
				logger.Error(HttpStatusCode.BadRequest);

				throw new HttpResponseException(HttpStatusCode.BadRequest);
			}

			try
			{
				logger.Trace("Service called: query");

				QueryResponse result = new QueryResponse();

				// Get Operations for a id
				result.Operations = Journal.Get(request.Id);

				// If tracking ID exists create operation instance and store in journal
				if (result.Operations == null)
				{
					logger.Info("There isn't operations for the id : + " + request.Id.ToString());
				}

				logger.Trace("Query success!!");

				return result;
			}
			catch (Exception ex)
			{
				logger.Error(ex);

				// An unexpected error condition was triggered which made impossible to fulfill the request
				throw new HttpResponseException(HttpStatusCode.InternalServerError);
			}

		}

	}
}
