
import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../services/authservice';

export const authGuard: CanActivateFn = () => {
    const authService = inject(AuthService);
    const router = inject(Router);

    // Check if the user has a valid session
    if (authService.isLoggedIn()) {
        return true; 
    }

    // Not logged in - redirect to Login page
    router.navigate(['/login']);
    return false;
};

