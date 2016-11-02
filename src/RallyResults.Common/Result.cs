using System;

namespace RallyResults.Common
{
	public class Result : RallyResults.Common.IResult
	{
		public RallyResults.Common.Status Status { get; private set; }
		public string Description { get; private set; }
		public object Value { get; private set; }

		public Result(
			RallyResults.Common.Status status,
			string description)
		{
			this.Status = status;
			this.Description = description;
		}


		public Result(
			RallyResults.Common.Status status,
			string description,
			object value)
		{
			this.Status = status;
			this.Description = description;
			this.Value = value;
		}
	}
}
