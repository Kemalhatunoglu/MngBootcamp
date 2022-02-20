import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ListResponseModel } from 'src/app/base-model/listResponseModel';
import { ResultModel } from 'src/app/base-model/resultModel';
import { environment } from 'src/environments/environment';
import { CarModel } from '../entity-model/car/carModel';

@Injectable({
  providedIn: 'root'
})
export class CarService {

  apiCarUrl = `${environment.baseUrl}Cars/`
  constructor(
    private http: HttpClient
  ) { }

  getAllCars(page: number, size: number): Observable<ResultModel<ListResponseModel<CarModel>>> {
    let newwPath = `${this.apiCarUrl}get-car-list?Page${page}PageSize=${size}`;
    return this.http.get<ResultModel<ListResponseModel<CarModel>>>(newwPath);
  }

  getCarById(id: number) {
    let newwPath = `${this.apiCarUrl}get-by-id?Id${id}`;
    return this.http.get<ResultModel<CarModel>>(newwPath);
  }
}
