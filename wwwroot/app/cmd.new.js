(function() {
   var createTodo = function(term, msg) {
      $.ajax({
         url: '/api/todo',
         method: 'POST',
         data: JSON.stringify({ message: msg }),
         contentType: 'application/json'
      }).done(function(result) {
         term.echo('id => ' + result.id);
      }).fail(function(xhr) {
         term.error(xhr.statusText);
      });
   };

   todo.app.commands.new = function(msg) {
      createTodo(this, msg);
   };

   todo.app.commands.new.usage = 'Create todo with message';
})();