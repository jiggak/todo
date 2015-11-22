(function() {
   var pad = function(s, len) {
      return (s + ' '.repeat(len)).slice(0, len);
   };

   var printHelp = function(term) {
      _.each(todo.app.commands, function(func, cmd) {
         term.echo(pad(cmd, 8) + func.usage);
      });
   };

   todo.app.commands.help = function(cmd) {
      printHelp(this);
   };

   todo.app.commands.help.usage = 'Show this help message';
})();