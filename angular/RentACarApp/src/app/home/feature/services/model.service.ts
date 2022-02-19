import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ListResponseModel } from 'src/app/core/baseModel/listResponseModel';
import { environment } from 'src/environments/environment';
import { ModelBaseModel } from '../../entity-model/model/modelBaseModel';
import { ModelListModel } from '../../entity-model/model/modelListModel';

@Injectable()
export class ModelService {

  apiModelUrl = `${environment.baseUrl}Models/`;

  constructor(
    private http: HttpClient
  ) { }

  getAllModels(page: number, size: number): Observable<ListResponseModel<ModelListModel>> {
    let newwPath = `${this.apiModelUrl}get-model-list?Page${page}PageSize=${size}`;
    return this.http.get<ListResponseModel<ModelListModel>>(newwPath);
  }

  addModel(addModel: ModelBaseModel): Observable<ModelBaseModel> {
    let newwPath = `${this.apiModelUrl}add`;
    return this.http.post<ModelBaseModel>(newwPath, addModel);
  }

  updateBrand(updateModel: ModelBaseModel): Observable<ModelBaseModel> {
    let newwPath = `${this.apiModelUrl}update`;
    return this.http.put<ModelBaseModel>(newwPath, updateModel);
  }

  deleteBrand(id: number) {
    let newwPath = `${this.apiModelUrl}delete/${id}`;
    this.http.delete<ModelBaseModel>(newwPath);
  }
}
