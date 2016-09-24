import { Component, OnInit } from '@angular/core';
import { TodoService } from './todo.service';
import { Observable } from 'rxjs';
import { Todo } from './todo';

@Component({
   selector: 'todo-app',
   templateUrl: './app.component.html',
   providers: [TodoService]
})
export class AppComponent implements OnInit {
   todos$: Observable<Todo[]>;

   constructor(private todoService: TodoService) { }

   ngOnInit(): void {
      this.reload();
   }

   reload(): void {
      this.todos$ = this.todoService.list();
   }

   save(message: string): void {
      this.todoService.create(new Todo(message))
         .then(x => this.reload());
   }

   delete(id: number): void {
      this.todoService.delete(id)
         .then(x => this.reload());
   }
}
