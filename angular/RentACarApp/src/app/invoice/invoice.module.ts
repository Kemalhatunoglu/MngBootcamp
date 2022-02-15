import { NgModule } from '@angular/core';
import { InvoiceComponent } from './invoice/invoice.component';
import { CoreModule } from '../core/core.module';


@NgModule({
  declarations: [
    InvoiceComponent
  ],
  imports: [
    CoreModule
  ],
  exports: [
    InvoiceComponent
  ]
})
export class InvoiceModule { }
