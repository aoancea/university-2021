import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { Duckbill } from './duckbill.models';

import { DuckbillService } from './duckbill.service';

@Component({
  selector: 'app-duckbill-add',
  templateUrl: './duckbill-add.component.html'
})
export class DuckbillAddComponent {

  public duckbill: Duckbill = <Duckbill>{};

  constructor(
    private duckbillService: DuckbillService,
    private router: Router) { }

  public saveDuckbill() {
    this.duckbillService.saveDuckbill(this.duckbill).subscribe(result => {
      this.router.navigateByUrl("/duckbills");
    }, error => console.error(error))
  }
}
