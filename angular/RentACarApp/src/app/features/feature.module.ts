import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrandComponent } from './brand/brand.component';
import { CarComponent } from './car/car.component';
import { CityComponent } from './city/city.component';
import { ColorComponent } from './color/color.component';
import { DamageRecordComponent } from './damage-record/damage-record.component';
import { ModelComponent } from './model/model.component';
import { FuelComponent } from './fuel/fuel.component';
import { TransmissionsComponent } from './transmissions/transmissions.component';
import { CoreModule } from '../core/core.module';
import { BrandService } from './services/brand.service';



@NgModule({
  declarations: [
    BrandComponent,
    CarComponent,
    CityComponent,
    ColorComponent,
    DamageRecordComponent,
    ModelComponent,
    FuelComponent,
    TransmissionsComponent
  ],
  imports: [
    CoreModule
  ],
  exports: [
    BrandComponent,
    CarComponent,
    CityComponent,
    ColorComponent,
    DamageRecordComponent,
    ModelComponent,
    FuelComponent
  ],
  providers: [
    BrandService
  ]
})
export class FeatureModule { }
