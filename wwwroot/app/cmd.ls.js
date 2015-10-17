(function() {
   var todoLine = _.template('<%= id %> | <%= moment(created).format("llll") %> | <%= message %>');

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

   todo.app.commands.ls.usage = 'List todos';
})();