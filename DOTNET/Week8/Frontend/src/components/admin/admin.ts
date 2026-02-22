// ============================================
// Admin Dashboard - Full employee management with
// CRUD (Create, Read, Update, Delete) operations
// Only accessible by users with the "Admin" role
// ============================================

import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { EmployeeService } from '../../services/employeeservice';
import { Employee } from '../../models/employee';

@Component({
    selector: 'app-admin',
    standalone: true,
    imports: [CommonModule, FormsModule],
    templateUrl: './admin.html',
    styleUrl: './admin.css'
})
export class Admin implements OnInit {
    // List of all employees fetched from the server
    employees: Employee[] = [];

    // UI state flags
    isLoading = true;
    showForm = false;     // Whether the add/edit modal is visible
    isEditing = false;    // true = editing existing, false = adding new

    // Feedback messages for the user
    errorMessage = '';
    successMessage = '';

    // Holds the employee being added or edited in the form
    currentEmployee: Employee = this.getEmptyEmployee();

    constructor(private employeeService: EmployeeService) { }

    ngOnInit(): void {
        this.loadEmployees();
    }

    // Returns a blank employee object for the "Add" form
    getEmptyEmployee(): Employee {
        return {
            id: 0,
            name: '',
            email: '',
            department: '',
            salary: 0,
            role: 'Employee',
            managerId: null,
            managerName: null
        };
    }

    // Get list of managers (Admin + Manager roles) for the Manager dropdown
    getManagers(): Employee[] {
        return this.employees.filter(e =>
            e.role === 'Admin' || e.role === 'Manager'
        );
    }

    // Fetch all employees from the backend
    loadEmployees(): void {
        this.isLoading = true;
        this.employeeService.getAll().subscribe({
            next: (data) => {
                this.employees = data;
                this.isLoading = false;
            },
            error: (err) => {
                this.errorMessage = err.userMessage || 'Failed to load employees. Please refresh the page.';
                this.isLoading = false;
            }
        });
    }

    // Open the modal in "Add" mode with a blank form
    openAddForm(): void {
        this.currentEmployee = this.getEmptyEmployee();
        this.isEditing = false;
        this.showForm = true;
        this.clearMessages();
    }

    // Open the modal in "Edit" mode pre-filled with the selected employee's data
    openEditForm(employee: Employee): void {
        this.currentEmployee = { ...employee };
        this.isEditing = true;
        this.showForm = true;
        this.clearMessages();
    }

    // Close the modal and reset the form
    closeForm(): void {
        this.showForm = false;
        this.currentEmployee = this.getEmptyEmployee();
    }

    // Create or update an employee depending on the current mode
    saveEmployee(): void {
        this.clearMessages();

        if (this.isEditing) {
            // Update existing employee
            this.employeeService.update(this.currentEmployee.id, this.currentEmployee).subscribe({
                next: () => {
                    this.successMessage = 'Employee updated successfully!';
                    this.closeForm();
                    this.loadEmployees();
                },
                error: (err) => {
                    this.errorMessage = err.userMessage || 'Failed to update employee. Please try again.';
                }
            });
        } else {
            // Create a new employee
            this.employeeService.create(this.currentEmployee).subscribe({
                next: () => {
                    this.successMessage = 'Employee added successfully!';
                    this.closeForm();
                    this.loadEmployees();
                },
                error: (err) => {
                    this.errorMessage = err.userMessage || 'Failed to add employee. Please try again.';
                }
            });
        }
    }

    // Remove an employee after confirmation
    deleteEmployee(id: number): void {
        if (confirm('Are you sure you want to delete this employee? This action cannot be undone.')) {
            this.clearMessages();
            this.employeeService.delete(id).subscribe({
                next: () => {
                    this.successMessage = 'Employee deleted successfully!';
                    this.loadEmployees();
                },
                error: (err) => {
                    this.errorMessage = err.userMessage || 'Failed to delete employee. Please try again.';
                }
            });
        }
    }

    // Reset both messages so old notifications don't linger
    clearMessages(): void {
        this.errorMessage = '';
        this.successMessage = '';
    }
}
