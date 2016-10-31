using System;
using System.Collections.Generic;


namespace RallyResults.Data.Models
{
	public class Event
	{
		public string name;
		public DateTime startdate;
		public DateTime finishdate;
		public string surface;
		public string image;
		public List<int> service;
		public List<int> endofday;
		public List<Category> category;
	}


	public class Category
	{
		public string type;
		public string @class;
	}
}
