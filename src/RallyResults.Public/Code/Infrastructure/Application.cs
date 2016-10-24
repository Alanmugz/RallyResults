using log4net;
using System;
using System.Web;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;


namespace RallyResults.Public.Code.Infrastructure
{
	public class Application : HttpApplication
	{
		private RallyResults.Public.Code.Infrastructure.CustomDependencyResolver c_customDependencyResolver;
		private ILog c_logger;


		protected void Application_Start()
		{
			var _loggingContext = string.Format("{0}.Application_Start", this.GetType().FullName);
			this.c_customDependencyResolver = new RallyResults.Public.Code.Infrastructure.CustomDependencyResolver();
			this.c_logger = this.c_customDependencyResolver.Logger;
			this.c_logger.InfoFormat("{0} Commencing", _loggingContext);

			GlobalConfiguration.Configure(this.RegisterRoutes);
			// see the following for logging and handling exceptions
			// http://www.asp.net/web-api/overview/error-handling/web-api-global-error-handling
			// http://www.asp.net/web-api/overview/releases/whats-new-in-aspnet-web-api-21#global-error
			// https://damienbod.wordpress.com/2014/02/12/exploring-web-api-exception-handling/
			this.ConfigureGlobalExceptionLogger(GlobalConfiguration.Configuration);
			this.ConfigureGlobalExceptionHandler(GlobalConfiguration.Configuration);
			GlobalConfiguration.Configuration.DependencyResolver = this.c_customDependencyResolver;

			this.c_logger.InfoFormat("{0} Completed", _loggingContext);
		}


		private void RegisterRoutes(
			HttpConfiguration configuration)
		{
			// See http://stackoverflow.com/questions/23258976/versioning-using-attribute-routing-in-asp-net-web-api
			configuration.MapHttpAttributeRoutes();
		}


		private void ConfigureGlobalExceptionLogger(
			HttpConfiguration configuration)
		{
			configuration.Services.Add(typeof(IExceptionLogger), new RallyResults.Public.Code.Infrastructure.GlobalExceptionLogger(this.c_logger));
		}


		private void ConfigureGlobalExceptionHandler(
			HttpConfiguration configuration)
		{
			configuration.Services.Replace(typeof(IExceptionHandler), new RallyResults.Public.Code.Infrastructure.GlobalExceptionHandler());
		}
	}
}