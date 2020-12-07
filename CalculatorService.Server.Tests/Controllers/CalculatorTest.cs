using RestSharp;
using System.Net;
using Newtonsoft.Json;
using System.Web.Http;
using CalculatorService.Server.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorService.Server.Tests.Controllers
{
	/// <summary>
	/// Unit tests for the basic arithmetic operations of the calculator
	/// </summary>
	[TestClass]
	public class CalculatorTest
	{
		[TestMethod]
		public void AddReturnOk()
		{
			// Arrange
			AddRequest testAddRequest = new AddRequest();

			testAddRequest.Addens = new int[] { 2, 2, 3 };

			// Act
			var client = new RestClient("http://localhost:54405/api/calculator/");

			var request = new RestRequest("add", Method.POST);

			string json = JsonConvert.SerializeObject(testAddRequest);

			request.AddJsonBody(json);

			var response = client.Execute(request);

			var proccessResponse = JsonConvert.DeserializeObject<AddResponse>(response.Content);

			// Assert
			Assert.AreEqual(7, proccessResponse.Sum);
		}

		[TestMethod]
		public void AddReturnBadRequest()
		{
			try
			{
				// Arrange
				AddRequest testAddRequest = new AddRequest();

				testAddRequest.Addens = null;

				// Act
				var client = new RestClient("http://localhost:54405/api/calculator/");

				var request = new RestRequest("add", Method.POST);

				string json = JsonConvert.SerializeObject(testAddRequest);

				request.AddJsonBody(json);

				var response = client.Execute(request);

				var proccessResponse = JsonConvert.DeserializeObject<AddResponse>(response.Content);
			}
			catch (HttpResponseException ex)
			{
				// Assert
				Assert.AreEqual(ex.Response.StatusCode, HttpStatusCode.BadRequest);
			}
		}

		[TestMethod]
		public void SubtractReturnOk()
		{
			// Arrange
			SubtractRequest testSubtractRequest = new SubtractRequest();

			testSubtractRequest.Minuend = 11;

			testSubtractRequest.Subtrahend = 5;

			// Act
			var client = new RestClient("http://localhost:54405/api/calculator/");

			var request = new RestRequest("sub", Method.POST);

			string json = JsonConvert.SerializeObject(testSubtractRequest);

			request.AddJsonBody(json);

			var response = client.Execute(request);

			var proccessResponse = JsonConvert.DeserializeObject<SubtractResponse>(response.Content);

			// Assert
			Assert.AreEqual(6, proccessResponse.Difference);
		}

		[TestMethod]
		public void SubtractReturnBadRequest()
		{
			try
			{
				// Arrange
				SubtractRequest testSubtractRequest = new SubtractRequest();

				// Act
				var client = new RestClient("http://localhost:54405/api/calculator/");

				var request = new RestRequest("sub", Method.POST);

				string json = JsonConvert.SerializeObject(testSubtractRequest);

				request.AddJsonBody(json);

				var response = client.Execute(request);

				var proccessResponse = JsonConvert.DeserializeObject<SubtractResponse>(response.Content);
			}
			catch (HttpResponseException ex)
			{
				// Assert
				Assert.AreEqual(ex.Response.StatusCode, HttpStatusCode.BadRequest);
			}
		}

		[TestMethod]
		public void MultiplyReturnOk()
		{
			// Arrange
			MultiplyRequest testMultyplyRequest = new MultiplyRequest();

			testMultyplyRequest.Factors = new int[] { 8, 3, 2 };

			// Act
			var client = new RestClient("http://localhost:54405/api/calculator/");

			var request = new RestRequest("mult", Method.POST);

			string json = JsonConvert.SerializeObject(testMultyplyRequest);

			request.AddJsonBody(json);

			var response = client.Execute(request);

			var proccessResponse = JsonConvert.DeserializeObject<MultiplyResponse>(response.Content);

			// Assert
			Assert.AreEqual(48, proccessResponse.Product);
		}

		[TestMethod]
		public void MultiplyReturnBadRequest()
		{
			try
			{
				// Arrange
				MultiplyRequest testMultyplyRequest = new MultiplyRequest();

				testMultyplyRequest.Factors = null;

				// Act
				var client = new RestClient("http://localhost:54405/api/calculator/");

				var request = new RestRequest("mult", Method.POST);

				string json = JsonConvert.SerializeObject(testMultyplyRequest);

				request.AddJsonBody(json);

				var response = client.Execute(request);

				var proccessResponse = JsonConvert.DeserializeObject<MultiplyResponse>(response.Content);
			}
			catch (HttpResponseException ex)
			{
				// Assert
				Assert.AreEqual(ex.Response.StatusCode, HttpStatusCode.BadRequest);
			}
		}

		[TestMethod]
		public void DivideReturnOk()
		{
			// Arrange
			DivideRequest testDivideRequest = new DivideRequest();

			testDivideRequest.Dividend = 11;

			testDivideRequest.Divisor = 2;

			// Act
			var client = new RestClient("http://localhost:54405/api/calculator/");

			var request = new RestRequest("div", Method.POST);

			string json = JsonConvert.SerializeObject(testDivideRequest);

			request.AddJsonBody(json);

			var response = client.Execute(request);

			var proccessResponse = JsonConvert.DeserializeObject<DivideResponse>(response.Content);

			DivideResponse compare = new DivideResponse { Quotient = 5, Remainder = 1 };

			// Assert
			Assert.AreEqual(5, proccessResponse.Quotient);

			Assert.AreEqual(1, proccessResponse.Remainder);
		}

		[TestMethod]
		public void DivideReturnBadRequest()
		{
			try
			{
				// Arrange
				DivideRequest testDivideRequest = null;

				// Act
				var client = new RestClient("http://localhost:54405/api/calculator/");

				var request = new RestRequest("div", Method.POST);

				string json = JsonConvert.SerializeObject(testDivideRequest);

				request.AddJsonBody(json);

				var response = client.Execute(request);

				var proccessResponse = JsonConvert.DeserializeObject<DivideResponse>(response.Content);

				DivideResponse compare = new DivideResponse { Quotient = 5, Remainder = 1 };
			}
			catch (HttpResponseException ex)
			{
				// Assert
				Assert.AreEqual(ex.Response.StatusCode, HttpStatusCode.BadRequest);
			}
		}

		[TestMethod]
		public void SquaredReturnOk()
		{
			// Arrange
			SqrtRequest testSqrtRequest = new SqrtRequest();

			testSqrtRequest.Number = 16;

			// Act
			var client = new RestClient("http://localhost:54405/api/calculator/");

			var request = new RestRequest("sqrt", Method.POST);

			string json = JsonConvert.SerializeObject(testSqrtRequest);

			request.AddJsonBody(json);

			var response = client.Execute(request);

			var proccessResponse = JsonConvert.DeserializeObject<SqrtResponse>(response.Content);

			// Assert
			Assert.AreEqual(4, proccessResponse.Square);
		}

		[TestMethod]
		public void SquareReturnBadRequest()
		{

			// Arrange
			SqrtRequest testSqrtRequest = new SqrtRequest();

			testSqrtRequest.Number = 16;

			// Act
			var client = new RestClient("http://localhost:54405/api/calculator/");

			var request = new RestRequest("sqrt", Method.POST);

			string json = JsonConvert.SerializeObject(testSqrtRequest);

			request.AddJsonBody(json);

			var response = client.Execute(request);

			var proccessResponse = JsonConvert.DeserializeObject<SqrtResponse>(response.Content);

			// Assert
			Assert.AreNotEqual(2, proccessResponse.Square);
		}

	}

}

