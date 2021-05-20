import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Duckbill } from './duckbill.models';

@Component({
  selector: 'app-duckbill',
  templateUrl: './duckbill.component.html'
})
export class DuckbillsComponent {
  public duckbills: Duckbill[];

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    this.loadDuckbills();
  }

  public deleteDuckbill(duckbill: Duckbill) {
    this.http.delete(this.baseUrl + 'api/duckbills/' + duckbill.id).subscribe(result => {
      this.loadDuckbills();
    }, error => console.error(error))
  }

  loadDuckbills() {
    this.http.get<Duckbill[]>(this.baseUrl + 'api/duckbills').subscribe(result => {
      this.duckbills = result;
    }, error => console.error(error));
  }
}
