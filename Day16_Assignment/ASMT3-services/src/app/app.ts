import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Calculator } from '../components/calculator/calculator';
import { Message } from '../components/Message/message';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet,Calculator,Message],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('ASMT3-services');
}
