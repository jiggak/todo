using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApp
{
   [Table("todo")]
   public class Todo
   {
      [Key]
      [Column("id")]
      public int Id { get; set; }
      
      [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
      [Column("created")]
      public DateTime Created { get; set; }
      
      [Required]
      [Column("message")]
      public string Message { get; set; }
   }
}