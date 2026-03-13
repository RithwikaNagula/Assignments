// ============================================
// App Routes - Maps URL paths to components
// and applies guards to protect restricted pages
// ============================================

import { Routes } from '@angular/router';
import { Login } from '../components/login/login';
import { Register } from '../components/register/register';
import { ForgotPassword } from '../components/forgotpassword/forgotpassword';
import { Admin } from '../components/admin/admin';
import { Manager } from '../components/manager/manager';
import { EmployeeDashboard } from '../components/employee/employee';
import { authGuard } from '../guards/authguard';
import { roleGuard } from '../guards/roleguard';

export const routes: Routes = [
    // Public routes — anyone can access these
    { path: 'login', component: Login },
    { path: 'register', component: Register },
    { path: 'forgot-password', component: ForgotPassword },

    // Protected routes — require login + correct role
    {
        path: 'admin',
        component: Admin,
        canActivate: [authGuard, roleGuard],
        data: { roles: ['Admin'] }     // Only Admins can access this
    },
    {
        path: 'manager',
        component: Manager,
        canActivate: [authGuard, roleGuard],
        data: { roles: ['Manager'] }   // Only Managers can access this
    },
    {
        path: 'employee',
        component: EmployeeDashboard,
        canActivate: [authGuard, roleGuard],
        data: { roles: ['Employee'] }  // Only Employees can access this
    },

    // Default and wildcard — redirect unknown paths to login
    { path: '', redirectTo: '/login', pathMatch: 'full' },
    { path: '**', redirectTo: '/login' }
];
