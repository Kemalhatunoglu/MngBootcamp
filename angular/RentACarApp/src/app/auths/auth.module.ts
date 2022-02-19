import { NgModule } from '@angular/core';
import { SharedModule } from '../core/shared.module';

import { AuthRoutingModule } from './auth-routing.module';
import { AuthService } from './auth-service/auth.service';
import { AuthComponent } from './auth/auth.component';


@NgModule({
  declarations: [
    AuthComponent
  ],
  imports: [
    AuthRoutingModule,
    SharedModule
  ],
  providers: [
    AuthService
  ],
  exports: [
    AuthComponent
  ]
})
export class AuthModule { }
