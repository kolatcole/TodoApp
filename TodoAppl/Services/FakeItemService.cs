using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoAppl.Models;

namespace TodoAppl.Services
{
	public class FakeItemService 
	{
		public Task<TodoItem[]> GetAsync()
		{

			var item1 = new TodoItem
			{
				Name = "First Item",
				DueAt = DateTime.Now.AddHours(5)
			};
			var item2 = new TodoItem
			{
				Name = "Second Item",
				DueAt = DateTime.Now.AddDays(34)
			};
			return Task.FromResult(new[] { item1, item2 });
		}
	}
}
