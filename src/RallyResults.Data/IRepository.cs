using System;


namespace RallyResults.Data
{
	public interface IRepository
	{
		RallyResults.Common.IResult InsertEvent(
			RallyResults.Common.Models.Data.Event subject);


		RallyResults.Common.IResult UpdateEvent(
			int id,
			RallyResults.Common.Models.Data.Event subject);


		RallyResults.Common.IResult DeleteEvent(
			int id);


		RallyResults.Common.IResult SelectEvent(
			int id);
	}
}
