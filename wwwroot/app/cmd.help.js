(function() {
   var printHelp = function(term) {
      _.each(todo.app.commands, function(func, cmd) {
         term.echo(cmd + '\t' + func.usage);
      });
   };

   todo.app.commands.help = function() {
      printHelp(this);
   };

   todo.app.commands.help.usage = 'Show this help message';
})();