import { Component, OnInit } from '@angular/core';
import { CarService } from '../../base-service/car.service';
import { CarDetailModel } from '../../entity-model/car/carDetailModel';

@Component({
  selector: 'app-car-carousel',
  templateUrl: './car-carousel.component.html',
  styleUrls: ['./car-carousel.component.css']
})
export class CarCarouselComponent implements OnInit {

  allCarsDetail: CarDetailModel[];
  indexImg: number = 1;

  displayCarDetailModel: boolean = false;
  selectedCar: CarDetailModel;

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
    this.getAllCarDetail();
  }

  getAllCarDetail() {
    this.carService.getAllCarDetail().subscribe(response => {
      this.allCarsDetail = response.data
    })
  }

  showCarDetail(car: CarDetailModel) {
    this.selectedCar = car;
    console.log(this.selectedCar)
    this.displayCarDetailModel = true;
  }
}
