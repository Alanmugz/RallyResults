using AutoMapper;
using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Web.Http.Dependencies;


namespace RallyResults.Public.Code.Infrastructure
{
	// See	http://www.asp.net/web-api/overview/extensibility/using-the-web-api-dependency-resolver
	public class CustomDependencyResolver : IDependencyResolver
	{
		private readonly string c_environment;
		private readonly ILog c_logger;
		private readonly IMapper c_mapper;


		public ILog Logger { get { return this.c_logger; } }
		public IMapper Mapper { get { return this.c_mapper; } }


		public CustomDependencyResolver()
		{
			XmlConfigurator.Configure();
			GlobalContext.Properties["pid"] = Process.GetCurrentProcess().Id;	// See http://stackoverflow.com/questions/2075603/log4net-process-id-information
			this.c_environment = ConfigurationManager.AppSettings["environment"];
			this.c_logger = LogManager.GetLogger(ConfigurationManager.AppSettings["defaultLoggerName"]);

			AutoMapper.Mapper.Initialize(cfg => cfg.CreateMap<RallyResults.Public.Models.Event, RallyResults.Data.Models.Event>());
			var config = new MapperConfiguration(cfg => {
				cfg.CreateMap<RallyResults.Public.Models.Event, RallyResults.Data.Models.Event>();
				cfg.CreateMap<RallyResults.Public.Models.Category, RallyResults.Data.Models.Category>();
			});

			c_mapper = new Mapper(config);
		}


		public IDependencyScope BeginScope()
		{
			return this;
		}


		public object GetService(
			Type serviceType)
		{
			var _loggingContext = string.Format("{0}.GetService", this.GetType().FullName);
			this.c_logger.DebugFormat("{0} Commencing", _loggingContext);

			if (serviceType == typeof(RallyResults.Public.Controllers.v1.Rally.rallyResultsController))
			{
				return new RallyResults.Public.Controllers.v1.Rally.rallyResultsController(
					this.c_logger, this.c_mapper);
			}

			return null;
		}


		public IEnumerable<object> GetServices(
			Type serviceType)
		{
			return new List<object>();
		}


		public void Dispose()
		{
		}
	}
}
