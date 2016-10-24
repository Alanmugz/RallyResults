using System;
using System.Collections.Generic;


namespace RallyResults.Public.Models
{
	public class Category
	{
		public string type { get; set; }
		public string @class { get; set; }
	}


	public class Event
	{
		public int id { get; set; }
		public string name { get; set; }
		public string startdate { get; set; }
		public string finishdate { get; set; }
		public string surface { get; set; }
		public string image { get; set; }
		public List<int> service { get; set; }
		public List<int> endofday { get; set; }
		public List<Category> category { get; set; }
	}
}
