using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoAppl.Models;
using TodoAppl.Data;

namespace TodoAppl.Services
{
	public interface ITodoItemService
	{
		Task<TodoItem[]> GetAsync(AppUser user);
		Task<bool> GetAsyncArray(TodoItem todoItem);
		Task<bool> MarkDoneAsync(Guid id);
	}
}
