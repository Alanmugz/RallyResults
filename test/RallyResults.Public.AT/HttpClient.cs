using System;
using System.Net.Http;
using System.Net.Http.Headers;


namespace RallyResults.Public.AT
{
	public class HttpClient : RallyResults.Public.AT.IHttpClient
	{
		//public HttpResponseMessage Post(
		//	string uri,
		//	string content)
		//{
		//	using (var client = new System.Net.Http.HttpClient())
		//	{
		//		client.BaseAddress = new Uri(uri);

		//		var _requestdata = new StringContent(content, Encoding.UTF8, "application/json");

		//		return client.PostAsync(uri, _requestdata).Result;
		//	}
		//}

		private readonly System.Net.Http.HttpClient c_httpClient;


		// TODO Need to look into .Result for async, used in every task
		public HttpClient()
		{
			this.c_httpClient = new System.Net.Http.HttpClient();
		}


		public HttpResponseMessage Get(
			string url,
			int timeout,
			AuthenticationHeaderValue authenticationHeaderValue = null)
		{
			this.c_httpClient.DefaultRequestHeaders.Authorization = authenticationHeaderValue;
			this.c_httpClient.Timeout = TimeSpan.FromMilliseconds(timeout);
			return this.c_httpClient.GetAsync(url).Result;
		}


		public HttpResponseMessage Post(
			string url,
			string content,
			string mediaTypeHeaderValue,
			AuthenticationHeaderValue authenticationHeaderValue = null)
		{
			var _content = new StringContent(content);
			_content.Headers.ContentType = new MediaTypeHeaderValue(mediaTypeHeaderValue);
			this.c_httpClient.DefaultRequestHeaders.Authorization = authenticationHeaderValue;
			return this.c_httpClient.PostAsync(url, _content).Result;
		}


		public void Dispose()
		{
			this.c_httpClient.Dispose();
		}
	}
}
