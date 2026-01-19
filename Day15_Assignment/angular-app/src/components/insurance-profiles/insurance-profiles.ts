import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-insurance-profiles',
  imports: [CommonModule],
  templateUrl: './insurance-profiles.html',
  styleUrl: './insurance-profiles.css',
})
export class InsuranceProfiles {
 selected = 0;

  profiles = [
    { name: 'Auto', img: 'assets/Images/auto.jfif' },
    { name: 'Auto + Home', img: 'assets/Images/auto-home.png' },
    { name: 'Home', img: 'assets/Images/home.jfif' },
    { name: 'Business', img: 'assets/Images/business.png' }
  ];

  selectCard(i: number) {
    this.selected = i;
  }
}
