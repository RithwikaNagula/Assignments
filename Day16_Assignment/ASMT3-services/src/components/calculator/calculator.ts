import { Component,inject } from '@angular/core';
import { Calculatorservice } from '../../services/calculatorservice/calculatorservice';


@Component({
  selector: 'app-calculator',
  imports: [],
  templateUrl: './calculator.html',
  styleUrl: './calculator.css',
})
export class Calculator{
  private calc = inject(Calculatorservice);
  result = 0;

  ngOnInit() {
    this.result = this.calc.add(10, 5);
  }

  add() {
    this.result = this.calc.add(10, 5);
  }

  sub() {
    this.result = this.calc.subtract(10, 5);
  }
}
