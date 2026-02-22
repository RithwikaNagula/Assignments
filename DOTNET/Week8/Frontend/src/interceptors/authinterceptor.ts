// ============================================
// Auth Interceptor - Attaches JWT token to every
// outgoing HTTP request so the backend knows who
// is making the call
// ============================================

import { HttpInterceptorFn } from '@angular/common/http';

export const authInterceptor: HttpInterceptorFn = (req, next) => {
    try {
        const token = localStorage.getItem('token');

        // If we have a token, clone the request and add the Authorization header
        // We clone because Angular HTTP requests are immutable by design
        if (token) {
            const cloned = req.clone({
                setHeaders: {
                    Authorization: `Bearer ${token}`
                }
            });
            return next(cloned);
        }
    } catch (error) {
        // localStorage might be unavailable in some browsers or private mode
        console.error('Auth interceptor: Could not access token', error);
    }

    // No token found — send the request as-is (for public endpoints like login)
    return next(req);
};
