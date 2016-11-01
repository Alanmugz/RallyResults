using AutoMapper;
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
		private readonly IMapper c_mapper;
		private RallyResults.Domain.Rally.Event c_rallyResultEvent;


		public rallyResultsEventController(
			ILog logger,
			IMapper mapper,
			RallyResults.Domain.Rally.Event eventsRepository)
		{
			Check.RequireArgumentNotNull("logger", logger);
			Check.RequireArgumentNotNull("mapper", mapper);
			Check.RequireArgumentNotNull("events Repository", eventsRepository);

			this.c_logger = logger;
			this.c_mapper = mapper;
			this.c_rallyResultEvent = eventsRepository;
		}


		[Route("insert/event")]
		public HttpResponseMessage Post(
			RallyResults.Domain.Models.Event @event)
		{
			var _loggingContext = string.Format("{0}.Post", this.GetType().FullName);
			this.c_logger.InfoFormat("{0} Commencing", _loggingContext);

			this.c_rallyResultEvent.ExecuteInsert(@event);

			this.c_logger.InfoFormat("{0} Completed", _loggingContext);

			//if (result == RallyResults.Data.Enumeration.Status.Success)
			//{
			//	return base.Request.CreateResponse(HttpStatusCode.Created);
			//}

			return base.Request.CreateResponse(HttpStatusCode.BadRequest);
		}


		[Route("update/event/id/{id}")]
		public HttpResponseMessage Put(
			int id,
			RallyResults.Domain.Models.Event @event)
		{
			var _loggingContext = string.Format("{0}.Put.", this.GetType().FullName);
			this.c_logger.InfoFormat("{0} Commencing", _loggingContext);
			
			this.c_rallyResultEvent.ExecuteUpdate(@event, id);

			this.c_logger.InfoFormat("{0} Completed", _loggingContext);

			//if (_result > RallyResults.Data.Enumeration.Status.Success)
			//{
			//	return base.Request.CreateResponse(HttpStatusCode.OK);
			//}

			return base.Request.CreateResponse(HttpStatusCode.BadRequest);
		}


		[Route("delete/event/id/{id}")]
		public HttpResponseMessage Delete(
			int id)
		{
			var _loggingContext = string.Format("{0}.Delete.", this.GetType().FullName);
			this.c_logger.InfoFormat("{0} Commencing", _loggingContext);

			this.c_rallyResultEvent.ExecuteDelete(id);

			this.c_logger.InfoFormat("{0} Completed", _loggingContext);

			//if (_result > RallyResults.Data.Enumeration.Status.Success)
			//{
			//	return base.Request.CreateResponse(HttpStatusCode.OK);
			//}

			return base.Request.CreateResponse(HttpStatusCode.BadRequest);
		}


		[Route("select/event/id/{id}")]
		public HttpResponseMessage Get(
			int id)
		{
			var _loggingContext = string.Format("{0}.Get.", this.GetType().FullName);
			this.c_logger.InfoFormat("{0} Commencing", _loggingContext);

			this.c_rallyResultEvent.ExecuteSelect(id);

			this.c_logger.InfoFormat("{0} Completed", _loggingContext);

			//if (_result != null)
			//{
			//	return base.Request.CreateResponse(HttpStatusCode.OK, _result);
			//}

			return base.Request.CreateResponse(HttpStatusCode.BadRequest);
		}
	}
}