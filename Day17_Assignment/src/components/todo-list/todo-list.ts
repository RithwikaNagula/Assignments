import { Component, OnInit } from '@angular/core';
import { Todoservice } from '../../services/todoservice';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-todo-list',
  imports: [FormsModule,CommonModule],
  templateUrl: './todo-list.html',
  styleUrl: './todo-list.css',
})
export class TodoList implements OnInit{
  todo:any[]=[];
  todoid:any={};

    newUser = {
    name: '',
    email: ''
  };

   isEdit = false;
  constructor(private todoservice:Todoservice){}
  ngOnInit(): void {
    //subscribe is to get response
    this.todoservice.getTodo().subscribe(response=>{
      this.todo=response;
    })
    this.todoservice.getTodoId(2).subscribe(data=>{
      this.todoid=data;
    })
    
  }
    addUser() {
    if (this.isEdit) {
      this.todoservice.updateTodo(this.newUser).subscribe(() => {
          this.resetForm();
          this.todoservice.getTodo().subscribe(response=>{
          this.todo=response;
    });
        });
    } else {
      this.todoservice.postTodo(this.newUser).subscribe(() => {
          this.resetForm();
          this.todoservice.getTodo().subscribe(response=>{
          this.todo=response;
    });
        });
    }
  }

  editUser(user: any) {
    this.newUser = { ...user };
    this.isEdit = true;
    this.todoid=user;
  }

  deleteUser(id: number) {
    this.todoservice.deleteTodo(id).subscribe(() => {
      this.todoservice.getTodo().subscribe(response=>{
      this.todo=response;
    });
      });
  }

  resetForm() {
    this.newUser = { name: '', email: '' };
    this.isEdit = false;
  }
}

