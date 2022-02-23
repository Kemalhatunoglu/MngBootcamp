import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ResultModel } from 'src/app/base-model/resultModel';
import { RentalAddModel } from 'src/app/home/entity-model/rental/rentalAddModel';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class RentalService {

  apiCarUrl = `${environment.baseUrl}Rental/`
  constructor(
    private http: HttpClient
  ) { }

  addRental(model: RentalAddModel) {
    let newwPath = `${this.apiCarUrl}add`;
    return this.http.post(newwPath, model)
  }
}
