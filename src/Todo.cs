using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApp
{
   public class Todo
   {
      [Key]
      public int Id { get; set; }
      
      [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
      public DateTime Created { get; set; }
      
      [Required]
      public string Message { get; set; }
   }
}