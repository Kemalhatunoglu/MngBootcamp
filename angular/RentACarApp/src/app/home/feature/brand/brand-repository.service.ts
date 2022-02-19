import { Injectable } from '@angular/core';
import { ListResponseModel } from 'src/app/core/baseModel/listResponseModel';
import { BrandAddModel } from '../../entity-model/brand/brandAddModel';
import { BrandListModel } from '../../entity-model/brand/brandListModel';
import { BrandModel } from '../../entity-model/brand/brandModel';
import { BrandService } from '../services/brand.service';

@Injectable()
export class BrandRepositoryService {

  brand: BrandModel;
  allBrands: ListResponseModel<BrandListModel> = { items: [] };

  constructor(
    private brandService: BrandService) { }

  getBrand(id: number) {
    this.brandService.getBrandById(id).subscribe(response => {
      this.brand = response;
    })
  }

  getBrandList(page: number, pageSize: number) {
    this.brandService.getAllBrands(page, pageSize).subscribe(response => {
      this.allBrands = response;
    })
  }

  addBrand(brandModel: BrandAddModel) {
    this.brandService.addBrand(brandModel).subscribe(response => {
    })
  }

  updateBrand(brandModel: BrandModel) {
    this.brandService.updateBrand(brandModel).subscribe(response => {
    });
  }
  deleteBrand(id: number) {
    this.brandService.deleteBrand(id).subscribe(response => {
    });
  }
}
