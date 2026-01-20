import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class Calculatorservice {
  add(a: number, b: number): number {
    return a + b;
  }

  subtract(a: number, b: number): number {
    return a - b;
  }
}
