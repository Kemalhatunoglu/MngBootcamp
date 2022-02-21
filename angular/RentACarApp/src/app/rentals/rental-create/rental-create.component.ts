import { Component, OnInit } from '@angular/core';
import { Navigation, Router } from '@angular/router';
import { CarService } from 'src/app/home/base-service/car.service';
import { CarDetailModel } from 'src/app/home/entity-model/car/carDetailModel';

@Component({
  selector: 'app-rental-create',
  templateUrl: './rental-create.component.html',
  styleUrls: ['./rental-create.component.css']
})
export class RentalCreateComponent implements OnInit {

  locationModel: any
  allCar: CarDetailModel[];

  constructor(
    private router: Router,
    private carService: CarService
  ) {
    let nav: Navigation = this.router.getCurrentNavigation();
    this.locationModel = nav.extras.state;
  }

  ngOnInit(): void {
    this.getAllCar();
  }


  getAllCar() {
    this.carService.getAllCarDetail().subscribe(res => {
      this.allCar = res.data;
      console.log(this.allCar);
    })
  }

  createRental() {

  }
}
