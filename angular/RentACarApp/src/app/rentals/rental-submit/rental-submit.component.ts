import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Navigation, Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { AdditionalService } from 'src/app/home/base-service/additional.service';
import { AdditionalServiceModel } from 'src/app/home/entity-model/additionalService/AdditionalServiceModel';
import { CarDetailModel } from 'src/app/home/entity-model/car/carDetailModel';
import { RentalAddModel } from 'src/app/home/entity-model/rental/rentalAddModel';

@Component({
  selector: 'app-rental-submit',
  templateUrl: './rental-submit.component.html',
  styleUrls: ['./rental-submit.component.css'],
  providers: [
    MessageService
  ]
})
export class RentalSubmitComponent implements OnInit {

  car: CarDetailModel;
  brandName: string;
  model: string;
  rentedCity: string;
  deliveryCity: string;
  rentedDate: Date;
  deliveryDate: Date;
  locationModel: any;

  additionalServices: any;
  selectedAdditional: any;

  allAdditionalService: AdditionalServiceModel[] = [];

  selectedAdditionalService: AdditionalServiceModel[] = []
  totalPriceWithAdditional: number = 0;
  otherModel: any;

  rentalAddModel: RentalAddModel = null;

  constructor(
    private router: Router,
    private messageService: MessageService,
    private additionalService: AdditionalService
  ) {
    let nav: Navigation = this.router.getCurrentNavigation();
    this.locationModel = nav.extras.state;
  }

  ngOnInit(): void {
    this.car = this.locationModel["currentModel"]
    this.otherModel = this.locationModel["otherDetail"]
    this.calcRentDate();
    this.getAllAdditionalService();
  }

  saveRental() {
    this.rentalAddModel = {
      carId: this.car.carId,
      customerId: 1,
      startDate: this.otherModel["currentModel"].rentedDate,
      endDate: this.otherModel["currentModel"].deliveryDate,
      rentedCityId: this.otherModel["currentModel"].rentedCity,
      deliveryCityId: this.otherModel["currentModel"].deliveryCity,
      additionalServiceIdList: [1, 2, 3]
    }

  }

  deleteAdditional(item: AdditionalServiceModel) {
    let deletedItem: AdditionalServiceModel = null;
    var filtered = this.selectedAdditionalService.filter(function (value, index, arr) {
      deletedItem = value;
      return value.id != item.id;
    });
    this.selectedAdditionalService = filtered;
    this.totalPriceWithAdditional -= deletedItem.dailyPrice;
    if (this.selectedAdditionalService.length === 0) {
      this.totalPriceWithAdditional = 0;
    }
  }

  onRowSelect(event: any) {
    this.totalPriceWithAdditional = 0;
    this.selectedAdditionalService.push(event.data);
    this.totalPriceWithAdditional += event.data.dailyPrice

    this.messageService.add({ severity: 'info', summary: 'Product Selected', detail: event.data.name });
  }

  getAllAdditionalService() {
    this.additionalService.getAllAdditional().subscribe(response => {
      this.allAdditionalService = response.data;
    })
  }

  calcRentDate() {
    console.log(this.otherModel["currentModel"].deliveryDate - this.otherModel["currentModel"].rentedDate);
  }
}
