// Manager Dashboard - View and edit employee data
// Managers can see all employees but cannot add or delete them (only Admins can do that)
import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { EmployeeService } from '../../services/employeeservice';
import { Employee } from '../../models/employee';

@Component({
    selector: 'app-manager',
    standalone: true,
    imports: [CommonModule, FormsModule],
    templateUrl: './manager.html',
    styleUrl: './manager.css'
})
export class Manager implements OnInit {
    // All employees fetched from the server
    employees: Employee[] = [];

    // UI state
    isLoading = true;
    showEditForm = false;
    showViewModal = false;

    // Feedback messages
    errorMessage = '';
    successMessage = '';

    // The employee currently being viewed or edited
    currentEmployee: Employee | null = null;
    editEmployee: Employee | null = null;

    constructor(private employeeService: EmployeeService) { }

    ngOnInit(): void {
        this.loadEmployees();
    }

    // Fetch the full employee list from the backend
    loadEmployees(): void {
        this.isLoading = true;
        this.employeeService.getAll().subscribe({
            next: (data) => {
                this.employees = data;
                this.isLoading = false;
            },
            error: (err) => {
                this.errorMessage = err.userMessage || 'Failed to load employees. Please try again.';
                this.isLoading = false;
            }
        });
    }

    // Open a read-only view of an employee's full profile
    viewEmployee(employee: Employee): void {
        this.currentEmployee = { ...employee };
        this.showViewModal = true;
        this.clearMessages();
    }

    // Open the edit form pre-filled with the selected employee's data
    openEditForm(employee: Employee): void {
        this.editEmployee = { ...employee };
        this.showEditForm = true;
        this.showViewModal = false;
        this.clearMessages();
    }

    closeEditForm(): void {
        this.showEditForm = false;
        this.editEmployee = null;
    }

    closeViewModal(): void {
        this.showViewModal = false;
        this.currentEmployee = null;
    }

    // Save changes to an employee's details
    updateEmployee(): void {
        if (!this.editEmployee) return;
        this.clearMessages();

        this.employeeService.update(this.editEmployee.id, this.editEmployee).subscribe({
            next: () => {
                this.successMessage = 'Employee updated successfully!';
                this.closeEditForm();
                this.loadEmployees(); // Refresh the cards
            },
            error: (err) => {
                this.errorMessage = err.userMessage || 'Failed to update employee. Please try again.';
            }
        });
    }

    clearMessages(): void {
        this.errorMessage = '';
        this.successMessage = '';
    }
}

