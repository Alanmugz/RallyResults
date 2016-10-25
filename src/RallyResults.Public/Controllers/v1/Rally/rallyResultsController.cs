﻿using log4net;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Check = CCS.Common.DBC.Check;


namespace RallyResults.Public.Controllers.v1.Rally
{
	[RoutePrefix("v1/rallyresults")]
	public class rallyResultsController : ApiController
	{
		private readonly ILog c_logger;


		public rallyResultsController(
			ILog logger)
		{
			Check.RequireArgumentNotNull("logger", logger);

			this.c_logger = logger;
		}


		[Route("insert/event")]
		public HttpResponseMessage Post(
			RallyResults.Public.Models.Event @event)
		{
			var _loggingContext = string.Format("{0}.Post", this.GetType().FullName);
			this.c_logger.InfoFormat("{0} Commencing", _loggingContext);

			this.c_logger.InfoFormat("{0} Completed", _loggingContext);

			return base.Request.CreateResponse(HttpStatusCode.Created, @event);
		}


		[Route("update/event")]
		public HttpResponseMessage Put(
			RallyResults.Public.Models.Event @event)
		{
			var _loggingContext = string.Format("{0}.Post", this.GetType().FullName);
			this.c_logger.InfoFormat("{0} Commencing", _loggingContext);

			this.c_logger.InfoFormat("{0} Completed", _loggingContext);

			return base.Request.CreateResponse(HttpStatusCode.OK);
		}
	}
}