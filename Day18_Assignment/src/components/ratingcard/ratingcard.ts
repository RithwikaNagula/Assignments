import { CommonModule } from '@angular/common';
import { Component,EventEmitter,Input,Output } from '@angular/core';

@Component({
  selector: 'app-ratingcard',
  imports: [CommonModule],
  templateUrl: './ratingcard.html',
  styleUrl: './ratingcard.css',
})
export class Ratingcard {
 @Input() productName!: string;
  @Output() rated = new EventEmitter<number>();

  selectedRating: number = 0;

  rate(star: number) {
    this.selectedRating = star;
    this.rated.emit(star);
  }
}
