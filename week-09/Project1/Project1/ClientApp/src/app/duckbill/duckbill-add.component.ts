import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Duckbill } from './duckbill.models';
import { Router } from '@angular/router';

@Component({
  selector: 'app-duckbill-add',
  templateUrl: './duckbill-add.component.html'
})
export class DuckbillAddComponent {

  public duckbill: Duckbill = <Duckbill>{};

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string,
    private router: Router) { }

  public saveDuckbill() {
    this.http.post(this.baseUrl + 'api/duckbills', this.duckbill).subscribe(result => {
      this.router.navigateByUrl("/duckbills");
    }, error => console.error(error))
  }
}
