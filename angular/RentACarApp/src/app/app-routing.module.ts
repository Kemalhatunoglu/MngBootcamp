import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: "", redirectTo: 'home', pathMatch: 'full' },
  {
    path: "home", loadChildren: () => import("./home/home.module")
      .then(m => m.HomeModule)
  },
  {
    path: "auth", loadChildren: () => import("./auths/auth.module")
      .then(m => m.AuthModule)
  },
  {
    path: "rental", loadChildren: () => import("./rentals/rental.module")
      .then(m => m.RentalModule)
  },
  {
    path: "feature", loadChildren: () => import("./home/feature/feature.module")
      .then(m => m.FeatureModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
