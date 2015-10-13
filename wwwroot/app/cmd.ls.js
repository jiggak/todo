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

   todo.app.commands.ls = function() {
      listTodos(this);
   };
})();