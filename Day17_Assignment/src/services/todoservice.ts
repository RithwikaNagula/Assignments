import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class Todoservice {
  //injection through constructor
  constructor(private http:HttpClient){}
  //user defined method (select many)
  getTodo(){
    return this.http.get<any[]>('http://localhost:3000/users');
  }
  // select one 
  getTodoId(id:number){
    return this.http.get<any>(`http://localhost:3000/users/${id}`);
  }
  postTodo(user: any) {
    return this.http.post('http://localhost:3000/users', user);
  }

  updateTodo(user: any) {
    return this.http.put(`http://localhost:3000/users`, user);
  }

  deleteTodo(id: number) {
    return this.http.delete(`${'http://localhost:3000/users'}/${id}`);
  }
}
