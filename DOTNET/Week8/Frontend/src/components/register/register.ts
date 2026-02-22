// ============================================
// Register Component - Lets new users create an
// account and pick their role (Admin/Manager/Employee)
// ============================================

import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../../services/authservice';

@Component({
    selector: 'app-register',
    standalone: true,
    imports: [CommonModule, FormsModule, RouterLink],
    templateUrl: './register.html',
    styleUrl: './register.css'
})
export class Register {
    // Form fields
    username = '';
    password = '';
    confirmPassword = '';
    email = '';
    role = '';

    // UI state
    errorMessage = '';
    successMessage = '';
    isLoading = false;

    // Available roles for the dropdown and role cards
    roles = ['Admin', 'Manager', 'Employee'];

    constructor(private authService: AuthService, private router: Router) { }

    // Validate the form and submit the registration request
    onRegister(): void {
        this.errorMessage = '';
        this.successMessage = '';

        // Make sure all required fields are filled in
        if (!this.username || !this.password || !this.email || !this.role) {
            this.errorMessage = 'Please fill in all required fields.';
            return;
        }

        // Check that both passwords match
        if (this.password !== this.confirmPassword) {
            this.errorMessage = 'Passwords do not match.';
            return;
        }

        // Enforce minimum password length for security
        if (this.password.length < 6) {
            this.errorMessage = 'Password must be at least 6 characters.';
            return;
        }

        // Simple email format check
        if (!this.email.includes('@') || !this.email.includes('.')) {
            this.errorMessage = 'Please enter a valid email address.';
            return;
        }

        // All validations passed — send registration to the server
        this.isLoading = true;
        this.authService.register({
            username: this.username,
            password: this.password,
            email: this.email,
            role: this.role
        }).subscribe({
            next: () => {
                this.isLoading = false;
                this.successMessage = 'Registration successful! Redirecting to login...';
                // Give the user a moment to see the success message before redirecting
                setTimeout(() => {
                    this.router.navigate(['/login']);
                }, 2000);
            },
            error: (err) => {
                this.isLoading = false;
                this.errorMessage = err.userMessage || err.error?.message || 'Registration failed. Please try again.';
            }
        });
    }
}
