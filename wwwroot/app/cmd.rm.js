(function() {
   var removeTodo = function(term, id) {
      $.ajax({
         url: '/api/todo/' + id,
         method: 'DELETE'
      }).fail(function(xhr) {
         term.error(xhr.statusText);
      });
   };

   todo.app.commands.rm = function(id) {
      removeTodo(this, id);
   };

   todo.app.commands.rm.usage = 'Remove todo with the ID';
})();