import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { EmployeeListComponent } from '../Components/employee-list/employee-list';
import {EmployeeFormComponent} from '../Components/employee-form/employee-form'

@Component({
  selector: 'app-root',
   
  imports: [RouterOutlet,EmployeeListComponent,EmployeeFormComponent],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('Employee');
}
