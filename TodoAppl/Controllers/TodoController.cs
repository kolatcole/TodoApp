using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoAppl.Services;
using TodoAppl.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using TodoAppl.Data;

namespace TodoAppl.Controllers
{
	[Authorize]

	public class TodoController : Controller
	
    {
		private readonly ITodoItemService todoItemService;
		private readonly UserManager<AppUser> userManager;
		public TodoController(ITodoItemService _todoItemService,UserManager<AppUser> _userManager) {
			todoItemService = _todoItemService;
			userManager = _userManager;
		}
		public async Task<IActionResult> Index()
        {

			var currentUser = await userManager.GetUserAsync(User);
			if (currentUser == null) return Challenge();
			var Item = await todoItemService.GetAsync(currentUser);
			var model = new TodoViewModel
			{
				item = Item
			};
            return View(model);
        }
		
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> AddItem(TodoItem newItem){
			if (!ModelState.IsValid) {
				
				RedirectToAction("Index");
			}
			var successful =await todoItemService.GetAsyncArray(newItem);
			if (!successful) {
				return BadRequest("Unable to Save");
			}

				return RedirectToAction("Index");
			
		}
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> MarkDone(Guid id) {

			if (id == Guid.Empty) {
				RedirectToAction("Index");
			}
			var succesful =await todoItemService.MarkDoneAsync(id);
			if (!succesful) {
				return BadRequest("Could not Mark");
			}
			return RedirectToAction("Index");

		}
    }
}