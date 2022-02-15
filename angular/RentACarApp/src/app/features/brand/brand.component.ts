import { Component, OnInit } from '@angular/core';
import { ListResponseModel } from 'src/app/core/baseModel/listResponseModel';
import { BrandListModel } from '../entity-model/brand/brandListModel';
import { BrandService } from '../services/brand.service';

@Component({
  selector: 'app-brand',
  templateUrl: './brand.component.html',
  styleUrls: ['./brand.component.css']
})
export class BrandComponent implements OnInit {

  allBrands: ListResponseModel<BrandListModel> = { items: [] };

  constructor(private brandService: BrandService) { }

  ngOnInit(): void {
    this.getBrandList();
  }

  getBrandList() {
    this.brandService.getAllBrands(0, 10).subscribe(response => {
      console.log(response);
      this.allBrands = response;
    })
  }
}
