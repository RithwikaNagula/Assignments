// Employee Service - CRUD operations for employees
import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, catchError, throwError } from 'rxjs';
import { Employee } from '../models/employee';

@Injectable({
    providedIn: 'root'
})
export class EmployeeService {
    private apiUrl = '/api/Employees';

    constructor(private http: HttpClient) { }

    // Fetch the full list of employees (used by Admin and Manager dashboards)
    getAll(): Observable<Employee[]> {
        return this.http.get<Employee[]>(this.apiUrl).pipe(
            catchError(this.handleError)
        );
    }

    // Fetch the logged-in user's own employee profile
    getMe(): Observable<Employee> {
        return this.http.get<Employee>(`${this.apiUrl}/me`).pipe(
            catchError(this.handleError)
        );
    }

    // Fetch a single employee by their ID (used by Employee dashboard for profile)
    getById(id: number): Observable<Employee> {
        return this.http.get<Employee>(`${this.apiUrl}/${id}`).pipe(
            catchError(this.handleError)
        );
    }

    // Create a new employee record (Admin only)
    create(employee: Employee): Observable<Employee> {
        return this.http.post<Employee>(this.apiUrl, employee).pipe(
            catchError(this.handleError)
        );
    }

    // Update an existing employee's details (Admin and Manager)
    update(id: number, employee: Employee): Observable<Employee> {
        return this.http.put<Employee>(`${this.apiUrl}/${id}`, employee).pipe(
            catchError(this.handleError)
        );
    }

    // Permanently remove an employee from the system (Admin only)
    delete(id: number): Observable<void> {
        return this.http.delete<void>(`${this.apiUrl}/${id}`).pipe(
            catchError(this.handleError)
        );
    }

    // Centralized error handler - gives user-friendly messages for common failures
    private handleError(error: HttpErrorResponse): Observable<never> {
        let message = 'An unexpected error occurred. Please try again.';

        if (error.status === 0) {
            message = 'Cannot reach the server. Please check your internet connection.';
        } else if (error.status === 404) {
            message = 'Employee not found. They may have been deleted.';
        } else if (error.status === 400) {
            message = 'Invalid data submitted. Please check the form fields.';
        } else if (error.status === 403) {
            message = 'You are not authorized to perform this action.';
        } else if (error.error?.message) {
            message = error.error.message;
        }

        return throwError(() => ({ ...error, userMessage: message }));
    }
}

