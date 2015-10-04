using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;

namespace TodoApp
{
   public class TodoStorage : DbContext
   {
      public DbSet<Todo> Todos { get; set; }
      
      protected override void OnConfiguring(DbContextOptionsBuilder options)
      {
         options.UseNpgsql("Server=localhost;User ID=josh;Database=todo");
         base.OnConfiguring(options);
      }
   }
}