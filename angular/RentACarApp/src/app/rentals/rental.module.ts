import { NgModule } from '@angular/core';
import { RentalComponent } from './rental/rental.component';
import { AdditionalServicesComponent } from './additional-services/additional-services.component';
import { SharedModule } from '../core/shared.module';


@NgModule({
  declarations: [
    AdditionalServicesComponent,
    RentalComponent
  ],
  imports: [
    SharedModule
  ],
  exports: [
    RentalComponent
  ]
})
export class RentalModule { }
