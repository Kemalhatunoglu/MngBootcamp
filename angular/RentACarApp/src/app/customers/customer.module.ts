import { NgModule } from '@angular/core';
import { CorporateCustomerComponent } from './corporate-customer/corporate-customer.component';
import { IndividualCustomersComponent } from './individual-customers/individual-customers.component';
import { CoreModule } from '../core/core.module';
import { FindeksCreditComponent } from './findeks-credit/findeks-credit.component';


@NgModule({
  declarations: [
    CorporateCustomerComponent,
    IndividualCustomersComponent,
    FindeksCreditComponent
  ],
  imports: [
    CoreModule
  ],
  exports:[
    CorporateCustomerComponent,
    IndividualCustomersComponent
  ]
})
export class CustomerModule { }
