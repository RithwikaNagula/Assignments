import { Injectable, signal, computed } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable, tap } from 'rxjs';
import { LoginCredentials, SignupRequest, TokenResponse, UserProfileDto } from '../models/auth';

@Injectable({
    providedIn: 'root',
})
export class AuthService {
    private readonly apiUrl = 'http://localhost:5004/api/auth'; // Adjust base URL as needed
    private readonly tokenKey = 'auth_token';
    private readonly userKey = 'auth_user';

    private readonly userState = signal<TokenResponse | null>(this.getStoredUser());

    isLoggedIn = computed(() => !!this.userState());
    currentUser = computed(() => this.userState());
    userRole = computed(() => this.userState()?.role);

    constructor(private http: HttpClient, private router: Router) { }

    login(credentials: LoginCredentials): Observable<TokenResponse> {
        return this.http.post<TokenResponse>(`${this.apiUrl}/login`, credentials).pipe(
            tap((res) => {
                this.setSession(res);
            })
        );
    }

    register(request: SignupRequest): Observable<string> {
        return this.http.post(`${this.apiUrl}/register`, request, { responseType: 'text' });
    }

    logout(): void {
        localStorage.removeItem(this.tokenKey);
        localStorage.removeItem(this.userKey);
        this.userState.set(null);
        this.router.navigate(['/login']);
    }

    getToken(): string | null {
        return localStorage.getItem(this.tokenKey);
    }

    private setSession(authResult: TokenResponse): void {
        localStorage.setItem(this.tokenKey, authResult.token);
        localStorage.setItem(this.userKey, JSON.stringify(authResult));
        this.userState.set(authResult);
    }

    private getStoredUser(): TokenResponse | null {
        const user = localStorage.getItem(this.userKey);
        return user ? JSON.parse(user) : null;
    }
}
