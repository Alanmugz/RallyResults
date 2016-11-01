using System;
using System.Collections.Generic;


namespace RallyResults.Public.Models
{
	public class Event
	{
		public readonly string name;
		public readonly DateTime startdate;
		public readonly DateTime finishdate;
		public readonly string surface;
		public readonly string image;
		public readonly List<int> service;
		public readonly List<int> endofday;
		public readonly List<Category> category;

		public Event(
			string name,
			DateTime startdate,
			DateTime finishdate,
			string surface,
			string image,
			List<int> service,
			List<int> endofday,
			List<Category> category)
		{
			this.name = name;
			this.startdate = startdate;
			this.finishdate = finishdate;
			this.surface = surface;
			this.image = image;
			this.service = service;
			this.endofday = endofday;
			this.category = category;
		}
	}


	public class Category
	{
		public readonly string type;
		public readonly string @class;

		public Category(
			string type,
			string @class)
		{
			this.type = type;
			this.@class = @class;
		}
	}
}
