// ============================================
// Employee Dashboard - Read-only profile view
// Employees can only see their own data here,
// they cannot edit or delete anything
// ============================================

import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmployeeService } from '../../services/employeeservice';
import { Employee } from '../../models/employee';

@Component({
    selector: 'app-employee',
    standalone: true,
    imports: [CommonModule],
    templateUrl: './employee.html',
    styleUrl: './employee.css'
})
export class EmployeeDashboard implements OnInit {
    // The logged-in employee's profile data
    employee: Employee | null = null;

    // UI state
    isLoading = true;
    errorMessage = '';

    constructor(
        private employeeService: EmployeeService
    ) { }

    ngOnInit(): void {
        this.loadProfile();
    }

    // Fetch the current employee's profile from the backend
    // The /me endpoint identifies the user from their JWT token
    loadProfile(): void {
        this.isLoading = true;

        this.employeeService.getMe().subscribe({
            next: (data) => {
                this.employee = data;
                this.isLoading = false;
            },
            error: (err) => {
                this.errorMessage = err.userMessage || 'Failed to load your profile. Please try again later.';
                this.isLoading = false;
            }
        });
    }
}
