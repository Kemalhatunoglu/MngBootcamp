import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RentalCreateComponent } from './rental-create/rental-create.component';
import { RentalSubmitComponent } from './rental-submit/rental-submit.component';
import { RentalComponent } from './rental/rental.component';

const routes: Routes = [
  {
    path: '', component: RentalComponent,
    // canActivate: [AuthGuard],
  },
  {
    path: 'rental/create', component: RentalCreateComponent,
    // canActivate: [AuthGuard],
  },
  {
    path: 'rental/submit', component: RentalSubmitComponent,
    // canActivate: [AuthGuard],
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RentalRoutingModule { }
