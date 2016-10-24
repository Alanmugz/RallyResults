using CCS.Common.Extension;
using log4net;
using System;
using System.Web.Http.ExceptionHandling;
using Check = CCS.Common.DBC.Check;


namespace RallyResults.Public.Code.Infrastructure
{
	public class GlobalExceptionLogger : ExceptionLogger
	{
		private readonly ILog c_logger;


		public GlobalExceptionLogger(
			ILog logger)
		{
			Check.RequireArgumentNotNull("logger", logger);

			this.c_logger = logger;
		}


		public override void Log(
			ExceptionLoggerContext context)
		{
			this.c_logger.ErrorFormat("Unhandled exception processing {0} for {1}: {2}",
				context.Request.Method,
				context.Request.RequestUri,
				context.Exception.InstrumentationString());
		}
	}
}