import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { MenubarModule } from 'primeng/menubar';

import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthInterceptor } from './core/interceptor/auth.interceptor';

import { AppComponent } from './app.component';
import { NavComponent } from './layout/nav/nav.component';
import { ErrorInterceptor } from './core/interceptor/error.interceptor';
import { CategoryComponent } from './layout/category/category.component';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    CategoryComponent
  ],
  imports: [
    AppRoutingModule,
    MenubarModule,
    HttpClientModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
