import { Component } from '@angular/core';

@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html'
})
export class CounterComponent {
  public currentCount = 0;

  public name = this.currentCount < 10 ? 'Ana' : 'Alex';

  public incrementCounter() {
    this.currentCount++;
    this.name = this.currentCount < 10 ? 'Ana' : 'Alex';
  }
}
