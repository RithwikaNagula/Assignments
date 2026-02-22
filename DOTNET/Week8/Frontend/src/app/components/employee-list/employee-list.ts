import { Component, inject, signal, OnInit } from '@angular/core';
import { EmployeeService } from '../../services/employeeservice';
import { AuthService } from '../../services/authservice';
import { EmployeeInfo } from '../../models/employee';
import { CurrencyPipe } from '@angular/common';

@Component({
  selector: 'app-employee-list',
  standalone: true,
  imports: [CurrencyPipe],
  templateUrl: './employee-list.html',
  styleUrl: './employee-list.css'
})
export class EmployeeListComponent implements OnInit {
  employees = signal<EmployeeInfo[]>([]);

  private employeeService = inject(EmployeeService);
  authService = inject(AuthService);

  ngOnInit() {
    this.loadEmployees();
  }

  loadEmployees() {
    this.employeeService.getAll().subscribe(data => this.employees.set(data));
  }

  deleteEmployee(id: number) {
    if (confirm('Are you sure you want to delete this employee?')) {
      this.employeeService.delete(id).subscribe(() => this.loadEmployees());
    }
  }
}
