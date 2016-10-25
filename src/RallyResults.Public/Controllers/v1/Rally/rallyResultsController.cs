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
	public class rallyResultsController : ApiController
	{
		private readonly ILog c_logger;
		private readonly IMapper c_mapper;
		private RallyResults.Data.Class1 c_repo = new RallyResults.Data.Class1();


		public rallyResultsController(
			ILog logger,
			IMapper mapper)
		{
			Check.RequireArgumentNotNull("logger", logger);
			Check.RequireArgumentNotNull("mapper", mapper);

			this.c_logger = logger;
			this.c_mapper = mapper;
		}


		[Route("insert/event")]
		public HttpResponseMessage Post(
			RallyResults.Public.Models.Event @event)
		{
			var _loggingContext = string.Format("{0}.Post", this.GetType().FullName);
			this.c_logger.InfoFormat("{0} Commencing", _loggingContext);

			var dest = this.c_mapper.Map<RallyResults.Public.Models.Event, RallyResults.Data.Models.Event>(@event);
			c_repo.Execute(dest);

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