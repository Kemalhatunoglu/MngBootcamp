import { NgModule } from '@angular/core';
import { SharedModule } from '../core/shared.module';
import { HomeRoutingModule } from './home-routing.module';

import { HomeComponent } from './home.component';
import { CarComponent } from './car/car.component';


@NgModule({
  declarations: [
    HomeComponent,
    CarComponent
  ],
  imports: [
    HomeRoutingModule,
    SharedModule
  ],
  exports: [
    HomeComponent,
    CarComponent
  ]
})
export class HomeModule { }
