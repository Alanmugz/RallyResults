using System;


namespace RallyResults.Common
{
	public interface IResult
	{
		RallyResults.Common.Status Status { get; }
		string Description { get; }
		object Value { get; }
	}
}
