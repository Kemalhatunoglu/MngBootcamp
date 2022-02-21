import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/core/shared.module';
import { FeatureComponent } from './feature/feature.component';

@NgModule({
  declarations: [
    FeatureComponent
  ],
  imports: [
    SharedModule
  ],
  exports: [
    FeatureComponent
  ],
  providers: [
  ]
})
export class FeatureModule { }
