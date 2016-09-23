import { Component, OnInit } from '@angular/core';
import { TodoService } from './todo.service';

@Component({
   selector: 'todo-app',
   templateUrl: './app.component.html',
   providers: [TodoService]
})
export class AppComponent implements OnInit {
   todos$;

   constructor(private todoService: TodoService) { }

   ngOnInit(): void {
      this.todos$ = this.todoService.list();
   }
}
