var todo = {
	app: { commands: {} }
};

$(document).ready(function () {
   $('body').terminal(todo.app.commands, {
   	prompt: 'todo> ',
   	checkArity: false, // optional command args
   	greetings: $("#greeting").text()
   });
});