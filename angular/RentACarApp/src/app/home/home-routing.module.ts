import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '../auths/guards/auth.guard';
import { CarComponent } from './car/car.component';
import { FeatureComponent } from './feature/feature/feature.component';
import { HomePageComponent } from './home-page/home-page.component';
import { HomeComponent } from './home.component';

const routes: Routes = [
  {
    path: '', component: HomeComponent,
    // canActivate: [AuthGuard],
    children: [
      { path: "", component: HomePageComponent },
    ]
  },
  { path: "car", component: CarComponent },
  { path: "feature", component: FeatureComponent }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomeRoutingModule { }
