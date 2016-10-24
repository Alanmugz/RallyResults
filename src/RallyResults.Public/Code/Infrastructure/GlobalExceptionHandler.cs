using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;


namespace RallyResults.Public.Code.Infrastructure
{
	public class GlobalExceptionHandler : ExceptionHandler
	{
		public override void Handle(
			ExceptionHandlerContext context)
		{
			var _errorResultContentAsJson = JsonConvert.SerializeObject(
				new { error_type = "internal_server_error", error_description = "internal_server_error" });
			context.Result = new ErrorResult { Content = _errorResultContentAsJson };
		}
	}


	internal class ErrorResult : IHttpActionResult
	{
		public string Content { get; set; }

		public Task<HttpResponseMessage> ExecuteAsync(
			CancellationToken cancellationToken)
		{
			var _response = new HttpResponseMessage(HttpStatusCode.InternalServerError) { Content = new StringContent(Content) };
			_response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

			return Task.FromResult(_response);
		}
	}
}