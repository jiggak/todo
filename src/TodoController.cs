using System;
using System.Linq;
using System.Threading.Tasks;
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
            return db.Todos
               .OrderByDescending(t => t.Created)
               .ToList();
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
      async public Task<Todo> Create([FromBody] Todo todo)
      {
         using (var db = new TodoStorage())
         {
            db.Todos.Add(todo);
            await db.SaveChangesAsync();
            return todo;
         }
      }
      
      [HttpDelete("{id:int}")]
      async public Task<IActionResult> Delete(int id)
      {
         using (var db = new TodoStorage())
         {
            var todo = db.Todos.FirstOrDefault(t => t.Id == id);
            
            if (todo == null)
               return HttpNotFound();
               
            db.Todos.Remove(todo);
            await db.SaveChangesAsync();
         }
         
         return new NoContentResult();
      }
   }
}