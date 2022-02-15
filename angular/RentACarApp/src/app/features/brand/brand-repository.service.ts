import { Injectable } from '@angular/core';
import { BrandListModel } from '../entity-model/brand/brandListModel';
import { BrandModel } from '../entity-model/brand/brandModel';

@Injectable({
  providedIn: 'root'
})
export class BrandRepositoryService {
  private brandModel: BrandModel;
  private brandListModel:BrandListModel[] = [];
  constructor() { }
}
