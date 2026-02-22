// ============================================
// Root App Component - The shell that holds the
// navbar and the router outlet for page content
// ============================================

import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Navbar } from '../components/navbar/navbar';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, Navbar],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  // The root component just renders the navbar and the active route
  // All the real work happens in the child components
}
