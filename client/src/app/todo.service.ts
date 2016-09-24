import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs';
import { Todo } from './todo';

@Injectable()
export class TodoService {
   constructor(private http:Http) { }

   list(): Observable<Todo[]> {
      return this.http.get('/api/todo')
         .map(res => res.json());
   }

   create(todo: Todo): Promise<any> {
      console.log(todo);
      return this.http.post('/api/todo', todo)
         .toPromise();
   }

   delete(id: number): Promise<any> {
      return this.http.delete(`/api/todo/${id}`)
         .toPromise();
   }
}
