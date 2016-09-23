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
}
