import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';

import { Duckbill } from './duckbill.models';

@Injectable({
  providedIn: 'root'
})
export class DuckbillService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  loadDuckbills() {
    return this.http.get<Duckbill[]>(this.baseUrl + 'api/duckbills');
  }

  public saveDuckbill(duckbill: Duckbill) {
    return this.http.post(this.baseUrl + 'api/duckbills', duckbill);
  }

  deleteDuckbill(duckbill: Duckbill) {
    return this.http.delete(this.baseUrl + 'api/duckbills/' + duckbill.id);
  }
}
