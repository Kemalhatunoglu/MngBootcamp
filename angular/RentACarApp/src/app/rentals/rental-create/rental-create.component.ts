import { Component, OnInit } from '@angular/core';
import { Navigation, Router } from '@angular/router';
import { ConfirmationService, MessageService } from 'primeng/api';
import { DialogService } from 'primeng/dynamicdialog';
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
  car: CarDetailModel
  selectedCar: CarDetailModel;

  showSubmitDialog: boolean = false;

  constructor(
    private router: Router,
    private carService: CarService,
    private messageService: MessageService,
    private confirmationService: ConfirmationService,
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
    })
  }

  deleteProduct(car: CarDetailModel) {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete ' + car.plate + '?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.allCar = this.allCar.filter(val => val.carId !== car.carId);
        this.car = null;
        this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Car Deleted', life: 3000 });
      }
    });
  }

  createRental(car: CarDetailModel) {
    this.router.navigate(["rental/submit"],
      { state: { currentModel: car, otherDetail: this.locationModel }, skipLocationChange: true });
  }
}

