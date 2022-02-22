import { NgModule } from '@angular/core';
import { RentalComponent } from './rental/rental.component';
import { AdditionalServicesComponent } from './additional-services/additional-services.component';
import { SharedModule } from '../core/shared.module';
import { RentalRoutingModule } from './rental-routing.module';
import { DropdownModule } from 'primeng/dropdown';
import { RentalCreateComponent } from './rental-create/rental-create.component';
import { DataViewModule } from 'primeng/dataview';
import { ConfirmationService, MessageService } from 'primeng/api';
import { RentalSubmitComponent } from './rental-submit/rental-submit.component';
import { DialogService, DynamicDialogModule } from 'primeng/dynamicdialog';
import { OverlayPanelModule } from 'primeng/overlaypanel';



@NgModule({
  declarations: [
    AdditionalServicesComponent,
    RentalComponent,
    RentalCreateComponent,
    RentalSubmitComponent
  ],
  imports: [
    SharedModule,
    RentalRoutingModule,
    DropdownModule,
    DataViewModule,
    OverlayPanelModule,
    DynamicDialogModule
  ],
  exports: [
    RentalComponent,
    RentalCreateComponent
  ],
  providers: [
    MessageService,
    ConfirmationService,
    DialogService
  ]
})
export class RentalModule { }
