import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Ratingcard } from '../components/ratingcard/ratingcard';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
   
  imports: [RouterOutlet,Ratingcard,CommonModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  products = [
    { id: 1, name: 'iPhone 16', rating: 0 },
    { id: 2, name: 'Samsung S24', rating: 0 },
    { id: 3, name: 'OnePlus 12', rating: 0 }
  ];

  onRated(productId: number, rating: number) {
    const product = this.products.find(p => p.id === productId);
    if (product) {
      product.rating = rating;
    }
  }
}
