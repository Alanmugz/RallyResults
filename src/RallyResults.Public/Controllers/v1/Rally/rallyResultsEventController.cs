using log4net;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Check = CCS.Common.DBC.Check;


namespace RallyResults.Public.Controllers.v1.Rally
{
	[RoutePrefix("v1/rallyresults")]
	public class rallyResultsEventController : ApiController
	{
		private readonly ILog c_logger;
		private RallyResults.Domain.Rally.Event c_rallyResultEvent;


		public rallyResultsEventController(
			ILog logger,
			RallyResults.Domain.Rally.Event events)
		{
			Check.RequireArgumentNotNull("logger", logger);
			Check.RequireArgumentNotNull("events", events);

			this.c_logger = logger;
			this.c_rallyResultEvent = events;
		}


		[Route("insert/event")]
		public HttpResponseMessage Post(
			RallyResults.Common.Models.Domain.Event @event)
		{
			var _loggingContext = string.Format("{0}.Post", this.GetType().FullName);
			this.c_logger.InfoFormat("{0} Commencing", _loggingContext);

			Check.RequireArgumentNotNull("event", nameof(@event));

			var _result = this.c_rallyResultEvent.ExecuteInsert(@event);

			this.c_logger.InfoFormat("{0} Completed", _loggingContext);

			if (_result.Status == RallyResults.Common.Status.Success)
			{
				return base.Request.CreateResponse(HttpStatusCode.Created);
			}

			return base.Request.CreateResponse(HttpStatusCode.BadRequest);
		}


		[Route("update/event/id/{id}")]
		public HttpResponseMessage Put(
			int id,
			RallyResults.Common.Models.Domain.Event @event)
		{
			var _loggingContext = string.Format("{0}.Put.", this.GetType().FullName);
			this.c_logger.InfoFormat("{0} Commencing", _loggingContext);

			Check.RequireArgumentNotNull("id", nameof(id));
			Check.RequireArgumentNotNull("event", nameof(@event));
			
			var _result = this.c_rallyResultEvent.ExecuteUpdate(@event, id);

			this.c_logger.InfoFormat("{0} Completed", _loggingContext);

			if (_result.Status == RallyResults.Common.Status.Success)
			{
				return base.Request.CreateResponse(HttpStatusCode.OK);
			}

			return base.Request.CreateResponse(HttpStatusCode.BadRequest);
		}


		[Route("delete/event/id/{id}")]
		public HttpResponseMessage Delete(
			int id)
		{
			var _loggingContext = string.Format("{0}.Delete.", this.GetType().FullName);
			this.c_logger.InfoFormat("{0} Commencing", _loggingContext);

			Check.RequireArgumentNotNull("id", nameof(id));

			var _result = this.c_rallyResultEvent.ExecuteDelete(id);

			this.c_logger.InfoFormat("{0} Completed", _loggingContext);

			if (_result.Status == RallyResults.Common.Status.Success)
			{
				return base.Request.CreateResponse(HttpStatusCode.OK);
			}

			return base.Request.CreateResponse(HttpStatusCode.BadRequest);
		}


		[Route("select/event/id/{id}")]
		public HttpResponseMessage Get(
			int id)
		{
			var _loggingContext = string.Format("{0}.Get.", this.GetType().FullName);
			this.c_logger.InfoFormat("{0} Commencing", _loggingContext);

			Check.RequireArgumentNotNull("id", nameof(id));

			var _result = this.c_rallyResultEvent.ExecuteSelect(id);

			this.c_logger.InfoFormat("{0} Completed", _loggingContext);

			if (_result.Status == RallyResults.Common.Status.Success)
			{
				return base.Request.CreateResponse(HttpStatusCode.OK, _result.Value);
			}

			return base.Request.CreateResponse(HttpStatusCode.BadRequest);
		}
	}
}