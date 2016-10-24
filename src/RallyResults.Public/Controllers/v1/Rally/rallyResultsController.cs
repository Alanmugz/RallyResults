using log4net;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Check = CCS.Common.DBC.Check;


namespace RallyResults.Public.Controllers.v1.Rally
{
	[RoutePrefix("rallyresults")]
	public class rallyResultsController : ApiController
	{
		private readonly ILog c_logger;


		public rallyResultsController(
			ILog logger)
		{
			Check.RequireArgumentNotNull("logger", logger);

			this.c_logger = logger;
		}


		[Route]
		public HttpResponseMessage Get()
		{
			var _loggingContext = string.Format("{0}.Post", this.GetType().FullName);
			this.c_logger.InfoFormat("{0} Commencing", _loggingContext);

			this.c_logger.InfoFormat("{0} Completed", _loggingContext);

			return base.Request.CreateResponse(HttpStatusCode.Created);
		}
	}
}