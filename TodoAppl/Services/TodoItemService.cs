using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoAppl.Models;
using TodoAppl.Data;
using Microsoft.EntityFrameworkCore;
namespace TodoAppl.Services
{
	public class TodoItemService:ITodoItemService
	{
		public readonly ApplicationDbContext context;

		public TodoItemService(ApplicationDbContext _context) {
			context = _context;
		}
		public async Task<TodoItem[]> GetAsync(AppUser user) {

			return await context.Items.Where(x => x.IsDue == false && x.UserId==user.Id).ToArrayAsync();
			
		}
		public async Task<bool> GetAsyncArray(TodoItem newItem) {

			newItem.ID = new Guid();
			newItem.DueAt = DateTimeOffset.Now.AddDays(6);
			newItem.IsDue = false;

			context.Items.Add(newItem);
		    var result=await context.SaveChangesAsync();
			return result == 1;
			
		}
		public async Task<bool> MarkDoneAsync(Guid id) {

			

			var check = await context.Items.Where(x => x.ID == id).SingleOrDefaultAsync();
			if (check == null) return false;

			check.IsDue = true;

			var result =await context.SaveChangesAsync();
			return result == 1;

		}
	}
}
