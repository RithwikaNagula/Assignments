
import { inject } from '@angular/core';
import { CanActivateFn, Router, ActivatedRouteSnapshot } from '@angular/router';
import { AuthService } from '../services/authservice';

export const roleGuard: CanActivateFn = (route: ActivatedRouteSnapshot) => {
    const authService = inject(AuthService);
    const router = inject(Router);

    // Each route defines which roles are allowed via route data
    const expectedRoles = route.data['roles'] as string[];
    const userRole = authService.getRole();

    // Allow access if the user's role is in the allowed list
    if (userRole && expectedRoles.includes(userRole)) {
        return true;
    }

    // Wrong role - send them back to login
    router.navigate(['/login']);
    return false;
};

