import { NgModule } from '@angular/core';
import { RentalComponent } from './rental/rental.component';
import { AdditionalServicesComponent } from './additional-services/additional-services.component';
import { SharedModule } from '../core/shared.module';
import { RentalRoutingModule } from './rental-routing.module';
import { DropdownModule } from 'primeng/dropdown';
import { RentalCreateComponent } from './rental-create/rental-create.component';
import { DataViewModule } from 'primeng/dataview';

@NgModule({
  declarations: [
    AdditionalServicesComponent,
    RentalComponent,
    RentalCreateComponent
  ],
  imports: [
    SharedModule,
    RentalRoutingModule,
    DropdownModule,
    DataViewModule
  ],
  exports: [
    RentalComponent,
    RentalCreateComponent
  ]
})
export class RentalModule { }
