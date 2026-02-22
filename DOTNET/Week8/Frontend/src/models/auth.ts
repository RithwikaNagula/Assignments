// ============================================
// Auth Models - Data shapes for authentication
// ============================================

// What the user sends when trying to log in
export interface LoginRequest {
    username: string;
    password: string;
}

// What the user sends when creating a new account
export interface RegisterRequest {
    username: string;
    password: string;
    email: string;
    role: string; // "Admin" | "Manager" | "Employee"
}

// What the user sends when requesting a password reset
export interface ForgotPasswordRequest {
    email: string;
}

// What the user sends when actually resetting the password
export interface ResetPasswordRequest {
    email: string;
    token: string;
    newPassword: string;
}

// What the server sends back after a successful login
export interface LoginResponse {
    token: string;   // JWT token for authenticating future requests
    role: string;    // Determines which dashboard the user sees
    username: string;
}

// Represents the currently logged-in user stored in memory
export interface User {
    username: string;
    role: string;
    token: string;
}
