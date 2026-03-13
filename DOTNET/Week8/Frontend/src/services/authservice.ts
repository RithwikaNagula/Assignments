// Auth Service - Handles login, register, logout,
// password reset, and user session management
import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import { BehaviorSubject, Observable, tap, catchError, throwError } from 'rxjs';
import {
    LoginRequest,
    LoginResponse,
    RegisterRequest,
    ForgotPasswordRequest,
    ResetPasswordRequest,
    User
} from '../models/auth';

@Injectable({
    providedIn: 'root'
})
export class AuthService {
    // Keeps track of who is currently logged in, so components can react to changes
    private currentUserSubject = new BehaviorSubject<User | null>(this.loadUser());
    currentUser$ = this.currentUserSubject.asObservable();

    private apiUrl = '/api/Auth';

    constructor(private http: HttpClient, private router: Router) { }

    // Try to restore the user session from localStorage on app startup
    // This way the user stays logged in even after a page refresh
    private loadUser(): User | null {
        try {
            const token = localStorage.getItem('token');
            const role = localStorage.getItem('role');
            const username = localStorage.getItem('username');

            if (token && role && username) {
                return { token, role, username };
            }
            return null;
        } catch (error) {
            // If localStorage is unavailable, fails
            console.error('Could not access localStorage:', error);
            return null;
        }
    }

    // Send credentials to the server and store the JWT token on success
    login(credentials: LoginRequest): Observable<LoginResponse> {
        return this.http.post<LoginResponse>(`${this.apiUrl}/login`, credentials).pipe(
            tap(response => {
                // Save session data so the user stays logged in across page reloads
                localStorage.setItem('token', response.token);
                localStorage.setItem('role', response.role);
                localStorage.setItem('username', response.username);

                // Notify all subscribers (navbar, guards, etc.) about the new user
                this.currentUserSubject.next({
                    token: response.token,
                    role: response.role,
                    username: response.username
                });
            }),
            catchError(this.handleError)
        );
    }

    // Create a new user account on the server
    register(data: RegisterRequest): Observable<unknown> {
        return this.http.post(`${this.apiUrl}/register`, data).pipe(
            catchError(this.handleError)
        );
    }

    // Request a password reset link to be sent to the user's email
    forgotPassword(data: ForgotPasswordRequest): Observable<unknown> {
        return this.http.post(`${this.apiUrl}/forgot-password`, data).pipe(
            catchError(this.handleError)
        );
    }

    // Submit a new password along with the reset token received via email
    resetPassword(data: ResetPasswordRequest): Observable<unknown> {
        return this.http.post(`${this.apiUrl}/reset-password`, data).pipe(
            catchError(this.handleError)
        );
    }

    // Clear all session data and send the user back to the login page
    logout(): void {
        try {
            localStorage.removeItem('token');
            localStorage.removeItem('role');
            localStorage.removeItem('username');
        } catch (error) {
            console.error('Error clearing localStorage:', error);
        }
        this.currentUserSubject.next(null);
        this.router.navigate(['/login']);
    }

    // Quick helpers for checking session state
    getToken(): string | null {
        try {
            return localStorage.getItem('token');
        } catch {
            return null;
        }
    }

    getRole(): string | null {
        try {
            return localStorage.getItem('role');
        } catch {
            return null;
        }
    }

    getUser(): User | null {
        return this.currentUserSubject.value;
    }

    isLoggedIn(): boolean {
        return !!this.getToken();
    }

    // After login, send the user to the right dashboard based on their role
    redirectByRole(): void {
        const role = this.getRole();
        switch (role) {
            case 'Admin':
                this.router.navigate(['/admin']);
                break;
            case 'Manager':
                this.router.navigate(['/manager']);
                break;
            case 'Employee':
                this.router.navigate(['/employee']);
                break;
            default:
                // Unknown role or missing data — go back to login
                this.router.navigate(['/login']);
        }
    }

    // Centralized error handler for all HTTP calls in this service
    // Extracts a user-friendly message from the server response
    private handleError(error: HttpErrorResponse): Observable<never> {
        let message = 'Something went wrong. Please try again later.';

        if (error.status === 0) {
            // Network error — server is unreachable
            message = 'Unable to connect to the server. Please check your connection.';
        } else if (error.status === 401) {
            message = 'Invalid credentials. Please check your username and password.';
        } else if (error.status === 403) {
            message = 'You do not have permission to perform this action.';
        } else if (error.status === 404) {
            message = 'The requested resource was not found.';
        } else if (error.status === 409) {
            message = 'This username or email is already registered.';
        } else if (error.error?.message) {
            // Use the message from the server if available
            message = error.error.message;
        }

        return throwError(() => ({ ...error, userMessage: message }));
    }
}

