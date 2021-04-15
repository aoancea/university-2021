import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Duckbill } from './duckbill.models';

@Component({
  selector: 'app-duckbill-add',
  templateUrl: './duckbill-add.component.html'
})
export class DuckbillAddComponent {

  public duckbill: Duckbill;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    //http.get<Duckbill[]>(baseUrl + 'api/duckbills').subscribe(result => {
    //  this.duckbills = result;
    //}, error => console.error(error));
  }
}
