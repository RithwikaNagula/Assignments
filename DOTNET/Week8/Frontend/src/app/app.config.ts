// ============================================
// App Config - Sets up global providers for
// the Angular application (routing, HTTP, etc.)
// ============================================

import { ApplicationConfig, provideZoneChangeDetection } from '@angular/core';
import { provideRouter } from '@angular/router';
import { provideHttpClient, withInterceptors } from '@angular/common/http';

import { routes } from './app.routes';
import { authInterceptor } from '../interceptors/authinterceptor';

export const appConfig: ApplicationConfig = {
  providers: [
    provideZoneChangeDetection({ eventCoalescing: true }),
    // Set up client-side routing using the routes defined in app.routes.ts
    provideRouter(routes),

    // Set up HTTP client with the JWT interceptor so every request
    // automatically includes the auth token in the header
    provideHttpClient(withInterceptors([authInterceptor]))
  ]
};
