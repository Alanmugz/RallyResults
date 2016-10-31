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
		private RallyResults.Data.IRepository c_eventsRepository;


		public rallyResultsEventController(
			ILog logger,
			IMapper mapper,
			RallyResults.Data.IRepository eventsRepository)
		{
			Check.RequireArgumentNotNull("logger", logger);
			Check.RequireArgumentNotNull("mapper", mapper);
			Check.RequireArgumentNotNull("events Repository", eventsRepository);

			this.c_logger = logger;
			this.c_mapper = mapper;
			this.c_eventsRepository = eventsRepository;
		}


		[Route("insert/event")]
		public HttpResponseMessage Post(
			RallyResults.Public.Models.Event @event)
		{
			var _loggingContext = string.Format("{0}.Post", this.GetType().FullName);
			this.c_logger.InfoFormat("{0} Commencing", _loggingContext);

			var _mappedEvent = this.c_mapper.Map<RallyResults.Public.Models.Event, RallyResults.Data.Models.Event>(@event);
			var result = c_eventsRepository.InsertEvent(_mappedEvent);

			this.c_logger.InfoFormat("{0} Completed", _loggingContext);

			if (result > 0)
			{
				return base.Request.CreateResponse(HttpStatusCode.Created);
			}

			return base.Request.CreateResponse(HttpStatusCode.BadRequest);
		}


		[Route("update/event/id/{id}")]
		public HttpResponseMessage Put(
			int id,
			RallyResults.Public.Models.Event @event)
		{
			var _loggingContext = string.Format("{0}.Put.", this.GetType().FullName);
			this.c_logger.InfoFormat("{0} Commencing", _loggingContext);

			var _mappedEvent = this.c_mapper.Map<RallyResults.Public.Models.Event, RallyResults.Data.Models.Event>(@event);
			var _result = c_eventsRepository.UpdateEvent(id, _mappedEvent);

			this.c_logger.InfoFormat("{0} Completed", _loggingContext);

			if (_result > 0)
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

			var _result = c_eventsRepository.DeleteEvent(id);

			this.c_logger.InfoFormat("{0} Completed", _loggingContext);

			if (_result > 0)
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

			var _result = c_eventsRepository.SelectEvent(id);

			this.c_logger.InfoFormat("{0} Completed", _loggingContext);

			if (_result != null)
			{
				return base.Request.CreateResponse(HttpStatusCode.OK, _result);
			}

			return base.Request.CreateResponse(HttpStatusCode.BadRequest);
		}
	}
}