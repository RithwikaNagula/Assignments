import { Component, inject, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../../services/authservice';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [FormsModule, RouterLink],
  templateUrl: './register.html', // Updated
  styleUrl: './register.css' // Updated
})
export class RegisterComponent {
  form = {
    username: '',
    fullName: '',
    email: '',
    password: '',
    role: 'Employee'
  };
  loading = signal(false);
  error = signal('');
  success = signal('');

  private authService = inject(AuthService);
  private router = inject(Router);

  onSubmit() {
    this.loading.set(true);
    this.error.set('');
    this.success.set('');
    this.authService.register(this.form)
      .subscribe({
        next: (msg) => {
          this.success.set(msg);
          setTimeout(() => this.router.navigate(['/login']), 2000);
        },
        error: (err: any) => {
          this.error.set(err.error || 'Registration failed');
          this.loading.set(false);
        }
      });
  }
}
