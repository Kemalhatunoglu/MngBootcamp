import { NgModule } from '@angular/core';
import { SharedModule } from '../core/shared.module';
import { HomeRoutingModule } from './home-routing.module';
import { DockModule } from 'primeng/dock';
import { CarouselModule } from 'primeng/carousel';
import { ButtonModule } from 'primeng/button';
import { ImageModule } from 'primeng/image';
import { CardModule } from 'primeng/card';
import { AvatarModule } from 'primeng/avatar';
import { AvatarGroupModule } from 'primeng/avatargroup';

import { HomeComponent } from './home.component';
import { CarComponent } from './car/car.component';
import { CategoryComponent } from './category/category.component';
import { CarCarouselComponent } from './car/car-carousel/car-carousel.component';
import { HomePageComponent } from './home-page/home-page.component';
import { FeatureModule } from './feature/feature.module';


@NgModule({
  declarations: [
    HomeComponent,
    CarComponent,
    CategoryComponent,
    CarCarouselComponent,
    HomePageComponent,
  ],
  imports: [
    HomeRoutingModule,
    SharedModule,
    FeatureModule,
    DockModule,
    CarouselModule,
    ButtonModule,
    ImageModule,
    CardModule,
    AvatarModule,
    AvatarGroupModule
  ],
  exports: [
    HomeComponent
  ]
})
export class HomeModule { }
