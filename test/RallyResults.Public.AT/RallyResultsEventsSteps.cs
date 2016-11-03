using NUnit.Framework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;


namespace RallyResults.Public.AT
{
	[Binding]
	public class RallyResultsEventsSteps
	{
		private RallyResults.Public.AT.HttpClient c_httpClient;
		private string c_event;


		[Given(@"I have a rally results event object ""(.*)""")]
		public void GivenIHaveARallyResultsEventObject(
			string request)
		{
			this.c_httpClient = new RallyResults.Public.AT.HttpClient();

			this.c_event = request;
		}

		
		[Given(@"I send a request to the API")]
		public void GivenISendARequestToTheAPI()
		{
			var _response = this.c_httpClient.Post("http://localhost:2235/v1/rallyresults/insert/event", this.c_event);

			ScenarioContext.Current.Add("resultcode", _response.StatusCode);
		}
		

		[Then(@"the result code should be ""(.*)""")]
		public void ThenTheResultCodeShouldBe(
			int resultcode)
		{
			Assert.AreEqual(resultcode, (int)ScenarioContext.Current["resultcode"]);
		}
	}
}
