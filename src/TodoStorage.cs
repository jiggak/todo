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
		
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			
			// DatabaseGenerated attribute not currently implemented in EF7
			builder.Entity<Todo>()
				.Property(t => t.Created)
				.StoreGeneratedPattern(StoreGeneratedPattern.Computed);
		}
	}
}