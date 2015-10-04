(function() {
   var todoLine = _.template('<%= id %> | <%= created %> | <%= message %>');

   var listTodos = function(term) {
      $.ajax('/api/todo').done(function(result) {
         _.each(result, function(todo) {
            term.echo(todoLine(todo));
         });
      }).fail(function(xhr) {
         term.error(xhr.statusText);
      });
   };

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

   var removeTodo = function(term, id) {
      $.ajax({
         url: '/api/todo/' + id,
         method: 'DELETE'
      }).fail(function(xhr) {
         term.error(xhr.statusText);
      });
   };

   var commands = {
      ls: function() {
         listTodos(this);
      },
      new: function(msg) {
         createTodo(this, msg);
      },
      rm: function(id) {
         removeTodo(this, id);
      }
   };

   $(document).ready(function () {
      $('body').terminal(commands, { prompt: 'todo> ', greetings: null });
   });

})();
