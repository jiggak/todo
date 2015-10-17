var todo = {
	app: { commands: {} }
};

$(document).ready(function () {
   $('body').terminal(todo.app.commands, {
   	prompt: 'todo> ',
   	greetings: $("#greeting").text()
   });
});