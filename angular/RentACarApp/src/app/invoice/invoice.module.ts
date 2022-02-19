import { NgModule } from '@angular/core';
import { SharedModule } from '../core/shared.module';

import { InvoiceComponent } from './invoice/invoice.component';


@NgModule({
  declarations: [
    InvoiceComponent
  ],
  imports: [
    SharedModule
  ],
  exports: [
    InvoiceComponent
  ]
})
export class InvoiceModule { }
