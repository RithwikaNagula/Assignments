import { Component, inject, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../../services/authservice';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule, RouterLink],
  templateUrl: './login.html',
  styleUrl: './login.css'
})
export class LoginComponent {
  username = '';
  password = '';
  loading = signal(false);
  error = signal('');

  private authService = inject(AuthService);
  private router = inject(Router);

  onSubmit() {
    this.loading.set(true);
    this.error.set('');
    this.authService.login({ username: this.username, password: this.password, captchaToken: 'mock' })
      .subscribe({
        next: () => this.router.navigate(['/employees']),
        error: (err: any) => {
          this.error.set(err.error || 'Login failed');
          this.loading.set(false);
        }
      });
  }
}
