using System;
using System.Net.Http;
using System.Net.Http.Headers;


namespace RallyResults.Public.AT
{
	public interface IHttpClient : IDisposable
	{
		HttpResponseMessage Get(
			string url,
			int timeout,
			AuthenticationHeaderValue authenticationHeaderValue = null);


		HttpResponseMessage Post(
			string url,
			string content,
			string mediaTypeHeaderValue,
			AuthenticationHeaderValue authenticationHeaderValue = null);
	}
}
