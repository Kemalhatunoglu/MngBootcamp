import { Injectable } from '@angular/core';
import { ListResponseModel } from 'src/app/base-model/listResponseModel';
import { ModelListModel } from '../../entity-model/model/modelListModel';
import { ModelService } from '../services/model.service';

@Injectable({
  providedIn: 'root'
})
export class ModelRepositoryService {

  allModels: ListResponseModel<ModelListModel> = { items: [] };


  constructor(
    private modelService: ModelService
  ) { }

  getAllModel(page: number, pageSize: number) {
    this.modelService.getAllModels(page, pageSize).subscribe(response => {
      this.allModels = response;
    });
  }
}
