using System;


namespace RallyResults.Data
{
	public interface IRepository
	{
		RallyResults.Data.Enumeration.Status InsertEvent(RallyResults.Data.Models.Event subject);


		RallyResults.Data.Enumeration.Status UpdateEvent(
			int id,
			RallyResults.Data.Models.Event subject);


		RallyResults.Data.Enumeration.Status DeleteEvent(
			int id);


		RallyResults.Data.AggregateRoot.Event SelectEvent(
			int id);
	}
}
