import { NgModule } from '@angular/core';
import { SharedModule } from '../core/shared.module';

import { CorporateCustomerComponent } from './corporate-customer/corporate-customer.component';
import { IndividualCustomersComponent } from './individual-customers/individual-customers.component';
import { FindeksCreditComponent } from './findeks-credit/findeks-credit.component';


@NgModule({
  declarations: [
    CorporateCustomerComponent,
    IndividualCustomersComponent,
    FindeksCreditComponent
  ],
  imports: [
    SharedModule
  ],
  exports: [
    CorporateCustomerComponent,
    IndividualCustomersComponent
  ]
})
export class CustomerModule { }
