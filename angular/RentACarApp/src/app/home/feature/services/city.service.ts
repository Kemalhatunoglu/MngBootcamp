import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ListResponseModel } from 'src/app/base-model/listResponseModel';
import { environment } from 'src/environments/environment';
import { CityListModel } from '../../entity-model/City/CityListModel';
import { CityModel } from '../../entity-model/City/CityModel';

@Injectable({
  providedIn: 'root'
})
export class CityService {

  apiCityUrl = `${environment.baseUrl}Cities/`
  constructor(
    private http: HttpClient
  ) { }

  getAllCities(page: number, size: number): Observable<ListResponseModel<CityListModel>> {
    let newwPath = `${this.apiCityUrl}get-city-list?Page${page}PageSize=${size}`;
    return this.http.get<ListResponseModel<CityListModel>>(newwPath);
  }

  addCity(cityModel: CityModel): Observable<CityModel> {
    let newwPath = `${this.apiCityUrl}add`;
    return this.http.post<CityModel>(newwPath, cityModel);
  }

  updateBrand(cityModel: CityModel): Observable<CityModel> {
    let newwPath = `${this.apiCityUrl}update`;
    return this.http.put<CityModel>(newwPath, cityModel);
  }

  deleteBrand(id: number): Observable<CityModel> {
    let newwPath = `${this.apiCityUrl}delete/${id}`;
    return this.http.delete<CityModel>(newwPath);
  }
}
