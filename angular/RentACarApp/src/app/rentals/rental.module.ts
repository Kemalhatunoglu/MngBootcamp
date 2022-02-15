import { NgModule } from '@angular/core';
import { RentalComponent } from './rental/rental.component';
import { AdditionalServicesComponent } from './additional-services/additional-services.component';
import { CoreModule } from '../core/core.module';


@NgModule({
  declarations: [
    AdditionalServicesComponent,
    RentalComponent
  ],
  imports: [
    CoreModule
  ],
  exports: [
    RentalComponent
  ]
})
export class RentalModule { }
