import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Employee } from '../models/employee';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

 

  constructor(private http: HttpClient) {}

  getEmployees(): Observable<Employee[]> {
    return this.http.get<Employee[]>("http://localhost:5087/api/Employee");
  }

  addEmployee(employee: Employee): Observable<Employee> {
    return this.http.post<Employee>("http://localhost:5087/api/Employee", employee);
  }
}
export type { Employee };

