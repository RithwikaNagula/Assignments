import { Component, Output, EventEmitter } from '@angular/core';
import { Employee } from '../../models/employee';
import { EmployeeService } from '../../Services/employee';
import { FormsModule } from '@angular/forms';

@Component({
  standalone: true,
  imports: [FormsModule],
  selector: 'app-employee-form',
  templateUrl: './employee-form.html'
})
export class EmployeeFormComponent {

  @Output() employeeAdded = new EventEmitter<void>();

  newEmployee: Employee = {
    name: '',
    email: '',
    department: '',
    salary: 0
  };

  constructor(private employeeService: EmployeeService) { }

  addEmployee() {
    this.employeeService.addEmployee(this.newEmployee).subscribe(() => {

      this.employeeAdded.emit(); // notify parent to reload list

      this.newEmployee = {
        name: '',
        email: '',
        department: '',
        salary: 0
      };
    });
  }
}
