import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ListResponseModel } from 'src/app/base-model/listResponseModel';
import { environment } from 'src/environments/environment';
import { BrandAddModel } from '../../entity-model/brand/brandAddModel';
import { BrandListModel } from '../../entity-model/brand/brandListModel';
import { BrandModel } from '../../entity-model/brand/brandModel';

@Injectable()
export class BrandService {

  apiBrandUrl = `${environment.baseUrl}Brands/`

  constructor(
    private http: HttpClient
  ) { }

  getAllBrands(page: number, size: number): Observable<ListResponseModel<BrandListModel>> {
    let newwPath = `${this.apiBrandUrl}get-brand-list?Page${page}PageSize=${size}`;
    return this.http.get<ListResponseModel<BrandListModel>>(newwPath);
  }

  getBrandById(id: number): Observable<BrandModel> {
    let newwPath = `${this.apiBrandUrl}get-by-id/${id}`;
    return this.http.get<BrandModel>(newwPath);
  }

  addBrand(brandModel: BrandAddModel): Observable<BrandAddModel> {
    let newwPath = `${this.apiBrandUrl}add`;
    return this.http.post<BrandModel>(newwPath, brandModel);
  }

  updateBrand(brandModel: BrandModel): Observable<BrandModel> {
    let newwPath = `${this.apiBrandUrl}update`;
    return this.http.put<BrandModel>(newwPath, brandModel);
  }

  deleteBrand(id: number): Observable<BrandModel> {
    let newwPath = `${this.apiBrandUrl}delete/${id}`;
    return this.http.delete<BrandModel>(newwPath);
  }
}
