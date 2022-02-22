import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RippleModule } from 'primeng/ripple';
import { SummaryPipe } from './pipe/summary.pipe';

import { ToastModule } from 'primeng/toast';
import { TabViewModule } from 'primeng/tabview';
import { DialogModule } from 'primeng/dialog';
import { ButtonModule } from 'primeng/button';
import { TableModule } from 'primeng/table';


@NgModule({
  declarations: [
    SummaryPipe
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule.withConfig({ warnOnNgModelWithFormControl: 'never' }),
    HttpClientModule,
    ToastModule,
    TabViewModule,
    TableModule,
    DialogModule,
    ButtonModule,
    RippleModule
  ],
  exports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    ToastModule,
    TabViewModule,
    RippleModule,
    TableModule,
    DialogModule,
    ButtonModule,
    SummaryPipe
  ],
  providers: [

  ]
})
export class SharedModule { }
