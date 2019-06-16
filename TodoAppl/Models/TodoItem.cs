using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoAppl.Models
{
	public class TodoItem
	{
		public string UserId { get; set; }
		public Guid ID {
			get;
			set;
		}
		public string  Name { get; set; }
		public DateTimeOffset DueAt { get; set; }
		public bool IsDue { get; set; }
	}
}
