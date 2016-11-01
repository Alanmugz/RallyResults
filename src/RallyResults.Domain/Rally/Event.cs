using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using RallyResults.Domain.Models;

namespace RallyResults.Domain.Rally
{
	public class Event
	{
		private readonly RallyResults.Data.IRepository c_eventsRepository;

		public Event(
			ILog logger)
		{
			this.c_eventsRepository = new RallyResults.Data.Repository(logger);
		}


		public void ExecuteInsert(
			RallyResults.Domain.Models.Event subject)
		{
			var _entry = this.MapEvent(subject);

			this.c_eventsRepository.InsertEvent(_entry);
		}

		

		public void ExecuteUpdate(
			RallyResults.Domain.Models.Event subject,
			int id)
		{
			var _entry = this.MapEvent(subject);

			this.c_eventsRepository.UpdateEvent(id, _entry);
		}


		public void ExecuteDelete(
			int id)
		{
			this.c_eventsRepository.DeleteEvent(id);
		}


		public void ExecuteSelect(
			int id)
		{
			this.c_eventsRepository.SelectEvent(id);
		}


		private RallyResults.Data.Models.Event MapEvent(
			RallyResults.Domain.Models.Event subject)
		{
			var categories = subject.category.Select(category => new RallyResults.Data.Models.Category(category.type, category.@class)).ToList();

			return new RallyResults.Data.Models.Event(
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
