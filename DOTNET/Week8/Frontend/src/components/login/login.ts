// ============================================
// Login Component - Handles user authentication
// with username, password, and CAPTCHA validation
// ============================================

import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../../services/authservice';

@Component({
    selector: 'app-login',
    standalone: true,
    imports: [CommonModule, FormsModule, RouterLink],
    templateUrl: './login.html',
    styleUrl: './login.css'
})
export class Login implements OnInit {
    // Reference to the canvas element where we draw the CAPTCHA
    @ViewChild('captchaCanvas', { static: true }) captchaCanvas!: ElementRef<HTMLCanvasElement>;

    // Form fields
    username = '';
    password = '';
    captchaInput = '';

    // Internal state
    captchaAnswer = '';     // The correct answer to the CAPTCHA math problem
    errorMessage = '';
    isLoading = false;

    constructor(private authService: AuthService, private router: Router) { }

    ngOnInit(): void {
        // If already logged in, skip the login page and go to the dashboard
        if (this.authService.isLoggedIn()) {
            this.authService.redirectByRole();
        }
        this.generateCaptcha();
    }

    // Draw a random math problem on the canvas with visual noise to prevent bots
    generateCaptcha(): void {
        try {
            const num1 = Math.floor(Math.random() * 20) + 1;
            const num2 = Math.floor(Math.random() * 20) + 1;
            const operators = ['+', '-', '*'];
            const operator = operators[Math.floor(Math.random() * operators.length)];

            // Calculate the answer based on the operator
            let answer: number;
            switch (operator) {
                case '+': answer = num1 + num2; break;
                case '-': answer = num1 - num2; break;
                case '*': answer = num1 * num2; break;
                default: answer = num1 + num2;
            }

            this.captchaAnswer = answer.toString();
            this.captchaInput = '';

            // Set up the canvas for drawing
            const canvas = this.captchaCanvas.nativeElement;
            const ctx = canvas.getContext('2d')!;
            canvas.width = 220;
            canvas.height = 60;

            // Draw a gradient background that matches the theme
            const gradient = ctx.createLinearGradient(0, 0, canvas.width, canvas.height);
            gradient.addColorStop(0, '#1e1b4b');
            gradient.addColorStop(1, '#312e81');
            ctx.fillStyle = gradient;
            ctx.fillRect(0, 0, canvas.width, canvas.height);

            // Add random lines to make it harder for bots to read
            for (let i = 0; i < 6; i++) {
                ctx.strokeStyle = `rgba(99, 102, 241, ${Math.random() * 0.5 + 0.2})`;
                ctx.lineWidth = 1;
                ctx.beginPath();
                ctx.moveTo(Math.random() * canvas.width, Math.random() * canvas.height);
                ctx.lineTo(Math.random() * canvas.width, Math.random() * canvas.height);
                ctx.stroke();
            }

            // Scatter random dots for additional noise
            for (let i = 0; i < 30; i++) {
                ctx.fillStyle = `rgba(129, 140, 248, ${Math.random() * 0.5})`;
                ctx.beginPath();
                ctx.arc(Math.random() * canvas.width, Math.random() * canvas.height, 1.5, 0, Math.PI * 2);
                ctx.fill();
            }

            // Write the math equation in the center of the canvas
            const text = `${num1} ${operator} ${num2} = ?`;
            ctx.font = 'bold 26px Inter, monospace';
            ctx.fillStyle = '#e0e7ff';
            ctx.textAlign = 'center';
            ctx.textBaseline = 'middle';
            ctx.fillText(text, canvas.width / 2, canvas.height / 2);
        } catch (error) {
            // Canvas might not be available in some edge cases
            console.error('Failed to generate CAPTCHA:', error);
        }
    }

    // Validate the form, check the CAPTCHA, and attempt login
    onLogin(): void {
        this.errorMessage = '';

        // Basic validation — make sure fields aren't empty
        if (!this.username || !this.password) {
            this.errorMessage = 'Please enter username and password.';
            return;
        }

        // Verify the user solved the CAPTCHA correctly
        if (this.captchaInput !== this.captchaAnswer) {
            this.errorMessage = 'Incorrect CAPTCHA. Please try again.';
            this.generateCaptcha();
            return;
        }

        // Everything looks good — try to authenticate with the server
        this.isLoading = true;
        this.authService.login({ username: this.username, password: this.password }).subscribe({
            next: () => {
                this.isLoading = false;
                // Login successful — send user to their role-specific dashboard
                this.authService.redirectByRole();
            },
            error: (err) => {
                this.isLoading = false;
                // Show the error message from the server, or a generic one
                this.errorMessage = err.userMessage || err.error?.message || 'Login failed. Please check your credentials.';
                this.generateCaptcha(); // Refresh CAPTCHA after failed attempt
            }
        });
    }
}
