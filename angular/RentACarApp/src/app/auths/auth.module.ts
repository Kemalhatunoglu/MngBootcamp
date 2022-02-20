import { NgModule } from '@angular/core';
import { MessageService } from 'primeng/api';
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
    AuthService,
    MessageService
  ],
  exports: [
    AuthComponent
  ]
})
export class AuthModule { }
