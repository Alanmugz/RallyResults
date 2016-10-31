using System;


namespace RallyResults.Data
{
	public interface IRepository
	{
		int InsertEvent(RallyResults.Data.Models.Event subject);


		int UpdateEvent(
			int id,
			RallyResults.Data.Models.Event subject);


		int DeleteEvent(
			int id);


		RallyResults.Data.AggregateRoot.Event SelectEvent(
			int id);
	}
}
