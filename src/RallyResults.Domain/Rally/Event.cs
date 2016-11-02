using log4net;
using System;
using System.Linq;

namespace RallyResults.Domain.Rally
{
	public class Event
	{
		private readonly RallyResults.Data.IRepository c_eventsRepository;

		public Event(
			ILog logger)
		{

		}


		public RallyResults.Common.IResult ExecuteInsert(
			RallyResults.Common.Models.Domain.Event subject)
		{
			var _entry = this.MapEvent(subject);

			return this.c_eventsRepository.InsertEvent(_entry);
		}

		

		public RallyResults.Common.IResult ExecuteUpdate(
			RallyResults.Common.Models.Domain.Event subject,
			int id)
		{
			var _entry = this.MapEvent(subject);

			return this.c_eventsRepository.UpdateEvent(id, _entry);
		}


		public RallyResults.Common.IResult ExecuteDelete(
			int id)
		{
			return this.c_eventsRepository.DeleteEvent(id);
		}


		public RallyResults.Common.IResult ExecuteSelect(
			int id)
		{
			return this.c_eventsRepository.SelectEvent(id);
		}


		private RallyResults.Common.Models.Data.Event MapEvent(
			RallyResults.Common.Models.Domain.Event subject)
		{
			var categories = subject.category.Select(category => new RallyResults.Common.Models.Data.Category(category.type, category.@class)).ToList();

			return new RallyResults.Common.Models.Data.Event(
				subject.name,
				subject.startdate,
				subject.finishdate,
				subject.surface,
				subject.image,
				subject.service,
				subject.endofday,
				categories);
		}
	}
}
