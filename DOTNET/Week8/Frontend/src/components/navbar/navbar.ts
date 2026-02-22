// ============================================
// Navbar Component - Top navigation bar that shows
// the logged-in user's info and provides logout
// ============================================

import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthService } from '../../services/authservice';
import { User } from '../../models/auth';

@Component({
    selector: 'app-navbar',
    standalone: true,
    imports: [CommonModule],
    templateUrl: './navbar.html',
    styleUrl: './navbar.css'
})
export class Navbar {
    // The currently logged-in user's data (null if not logged in)
    user: User | null = null;

    constructor(private authService: AuthService) {
        // Subscribe to user changes so the navbar updates automatically
        // when login/logout happens
        this.authService.currentUser$.subscribe(user => {
            this.user = user;
        });
    }

    // Helper to decide whether to show the navbar at all
    get isLoggedIn(): boolean {
        return this.authService.isLoggedIn();
    }

    // Clear session and return to login page
    logout(): void {
        this.authService.logout();
    }
}
