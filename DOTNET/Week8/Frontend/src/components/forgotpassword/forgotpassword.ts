// Works the same way regardless of user role
import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../../services/authservice';

@Component({
    selector: 'app-forgot-password',
    standalone: true,
    imports: [CommonModule, FormsModule, RouterLink],
    templateUrl: './forgotpassword.html',
    styleUrl: './forgotpassword.css'
})
export class ForgotPassword {
    // Single-step fields
    email = '';
    newPassword = '';
    confirmPassword = '';

    // UI state
    isLoading = false;
    errorMessage = '';
    successMessage = '';

    constructor(private authService: AuthService, private router: Router) { }

    // Submit the new password directly
    onResetPassword(): void {
        this.clearMessages();

        // Validate all fields are present
        if (!this.email || !this.newPassword || !this.confirmPassword) {
            this.errorMessage = 'Please fill in all fields.';
            return;
        }

        // Basic email validation
        if (!this.email.includes('@') || !this.email.includes('.')) {
            this.errorMessage = 'Please enter a valid email address.';
            return;
        }

        // Make sure the passwords match
        if (this.newPassword !== this.confirmPassword) {
            this.errorMessage = 'Passwords do not match.';
            return;
        }

        // Enforce minimum password length
        if (this.newPassword.length < 6) {
            this.errorMessage = 'Password must be at least 6 characters.';
            return;
        }

        this.isLoading = true;
        this.authService.resetPassword({
            email: this.email,
            token: 'bypass-token',
            newPassword: this.newPassword
        }).subscribe({
            next: () => {
                this.isLoading = false;
                this.successMessage = 'Password reset successful! Redirecting to login...';
                // Let the user see the success message, then redirect
                setTimeout(() => {
                    this.router.navigate(['/login']);
                }, 2000);
            },
            error: (err) => {
                this.isLoading = false;
                this.errorMessage = err.userMessage || 'Password reset failed. Please try again.';
            }
        });
    }

    clearMessages(): void {
        this.errorMessage = '';
        this.successMessage = '';
    }
}

