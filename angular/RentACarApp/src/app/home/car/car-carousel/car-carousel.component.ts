import { Component, OnInit } from '@angular/core';
import { CarService } from '../../base-service/car.service';
import { CarModel } from '../../entity-model/car/carModel';

@Component({
  selector: 'app-car-carousel',
  templateUrl: './car-carousel.component.html',
  styleUrls: ['./car-carousel.component.css']
})
export class CarCarouselComponent implements OnInit {

  carModel: CarModel[];
  indexImg: number = 1;
  responsiveOptions;

  constructor(private carService: CarService) {
    this.responsiveOptions = [
      {
        breakpoint: '1024px',
        numVisible: 3,
        numScroll: 3
      },
      {
        breakpoint: '768px',
        numVisible: 2,
        numScroll: 2
      },
      {
        breakpoint: '560px',
        numVisible: 1,
        numScroll: 1
      }
    ];
  }

  ngOnInit() {
    this.carService.getAllCars(0, 10).subscribe(response => {
      this.carModel = response.data.items;
    });
  }
}
