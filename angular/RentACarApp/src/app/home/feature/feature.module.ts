import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/core/shared.module';
import { BrandRepositoryService } from './brand/brand-repository.service';
import { CityRepositoryService } from './city/city-repository.service';
import { ModelRepositoryService } from './model/model-repository.service';

@NgModule({
  declarations: [

  ],
  imports: [
    SharedModule
  ],
  exports: [

  ],
  providers: [
    BrandRepositoryService,
    CityRepositoryService,
    ModelRepositoryService
  ]
})
export class FeatureModule { }
