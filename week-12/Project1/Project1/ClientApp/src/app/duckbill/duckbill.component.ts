import { Component } from '@angular/core';
import { Duckbill } from './duckbill.models';
import { DuckbillService } from './duckbill.service';

@Component({
  selector: 'app-duckbill',
  templateUrl: './duckbill.component.html'
})
export class DuckbillsComponent {
  public duckbills: Duckbill[];

  constructor(private duckbillService: DuckbillService) {
    this.loadDuckbills();
  }

  public deleteDuckbill(duckbill: Duckbill) {
    this.duckbillService.deleteDuckbill(duckbill).subscribe(result => {
      this.loadDuckbills();
    }, error => console.error(error))
  }

  loadDuckbills() {
    this.duckbillService.loadDuckbills().subscribe(result => {
      this.duckbills = result;
    }, error => console.error(error));
  }
}
