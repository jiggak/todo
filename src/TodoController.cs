using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNet.Mvc;

namespace TodoApp
{
	[Route("api/[controller]")]
	public class TodoController : Controller
	{
		[HttpGet]
		public IEnumerable<Todo> GetAll()
		{
			using (var db = new TodoStorage())
			{
				return db.Todos.ToList();
			}
		}
		
		[HttpGet("{id:int}")]
		public IActionResult GetById(int id)
		{
			using (var db = new TodoStorage())
			{
				var todo = db.Todos.FirstOrDefault(t => t.Id == id);
				
				if (todo == null)
					return HttpNotFound();
				
				return new ObjectResult(todo);
			}
		}
		
		[HttpPost]
		public Todo Create([FromBody] Todo todo)
		{
			using (var db = new TodoStorage())
			{
				db.Todos.Add(todo);
				db.SaveChanges();
				return todo;
			}
		}
		
		[HttpDelete("{id:int}")]
		public IActionResult Delete(int id)
		{
			using (var db = new TodoStorage())
			{
				var todo = db.Todos.FirstOrDefault(t => t.Id == id);
				
				if (todo == null)
					return HttpNotFound();
					
				db.Todos.Remove(todo);
				db.SaveChanges();
			}
			
			return new NoContentResult();
		}
	}
}