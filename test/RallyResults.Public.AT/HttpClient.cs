using System;
using System.Net.Http;
using System.Text;


namespace RallyResults.Public.AT
{
	public class HttpClient
	{
		public HttpResponseMessage Post(
			string uri,
			string content)
		{
			using (var client = new System.Net.Http.HttpClient())
			{
				client.BaseAddress = new Uri(uri);

				var _requestdata = new StringContent(content, Encoding.UTF8, "application/json");

				return client.PostAsync(uri, _requestdata).Result;
			}
		}
	}
}
