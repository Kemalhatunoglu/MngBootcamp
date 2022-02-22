import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ListResponseModel } from 'src/app/base-model/listResponseModel';
import { ResultModel } from 'src/app/base-model/resultModel';
import { environment } from 'src/environments/environment';
import { AdditionalServiceModel } from '../entity-model/additionalService/AdditionalServiceModel';

@Injectable({
  providedIn: 'root'
})
export class AdditionalService {

  apiCarUrl = `${environment.baseUrl}AdditionalServices/`

  constructor(
    private http: HttpClient
  ) { }

  getAllAdditional(): Observable<ResultModel<AdditionalServiceModel[]>> {
    let newwPath = `${this.apiCarUrl}`;
    return this.http.get<ResultModel<AdditionalServiceModel[]>>(newwPath);
  }
}
