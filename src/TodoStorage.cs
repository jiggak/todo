using Microsoft.Data.Entity;

namespace TodoApp
{
   public class TodoStorage : DbContext
   {
      public DbSet<Todo> Todos { get; set; }
      
      protected override void OnConfiguring(DbContextOptionsBuilder options)
      {
         //options.UseNpgsql("Server=localhost;User ID=josh;Database=todo");
         options.UseSqlite("Filename=todo.sqlite");
         base.OnConfiguring(options);
      }
   }
}