import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Navigation, Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { AdditionalService } from 'src/app/home/base-service/additional.service';
import { AdditionalServiceModel } from 'src/app/home/entity-model/additionalService/AdditionalServiceModel';
import { CarDetailModel } from 'src/app/home/entity-model/car/carDetailModel';
import { RentalAddModel } from 'src/app/home/entity-model/rental/rentalAddModel';
import { RentalService } from '../service/rental.service';

@Component({
  selector: 'app-rental-submit',
  templateUrl: './rental-submit.component.html',
  styleUrls: ['./rental-submit.component.css'],
  providers: [

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
  numberOfRentedDays: number = 1;
  addCityPrice: number = 0;
  allAdditionServiceIds: number[] = [];


  constructor(
    private router: Router,
    private messageService: MessageService,
    private additionalService: AdditionalService,
    private rentalService: RentalService
  ) {
    let nav: Navigation = this.router.getCurrentNavigation();
    this.locationModel = nav.extras.state;
  }

  ngOnInit(): void {
    this.car = this.locationModel["currentModel"]
    this.otherModel = this.locationModel["otherDetail"]
    this.calcRentDate();
    this.getAllAdditionalService();
    this.checkCity()
  }

  saveRental() {
    this.rentalAddModel = {
      carId: this.car.carId,
      customerId: 1,
      startDate: this.otherModel["currentModel"].rentedDate,
      endDate: this.otherModel["currentModel"].deliveryDate,
      rentedCityId: this.otherModel["currentModel"].rentedCity,
      deliveryCityId: this.otherModel["currentModel"].deliveryCity,
      additionalServiceIdList: this.allAdditionServiceIds
    }
    this.rentalService.addRental(this.rentalAddModel);
    this.messageService.add({ severity: 'success', summary: 'Ekleme başarılı', life: 3000 });

    setTimeout((x: any) => {
      this.router.navigate([""]);
    }, 3000);
  }

  deleteAdditional(item: AdditionalServiceModel) {
    this.allAdditionServiceIds = [];

    let deletedItem: AdditionalServiceModel = null;
    var filtered = this.selectedAdditionalService.filter(function (value, index, arr) {
      deletedItem = value;
      return value.id != item.id;
    });

    this.selectedAdditionalService = filtered;

    filtered.forEach(el => {
      this.allAdditionServiceIds.push(el.id)
    })

    this.totalPriceWithAdditional -= deletedItem.dailyPrice;
    if (this.selectedAdditionalService.length === 0) {
      this.totalPriceWithAdditional = 0;
    }
  }

  onRowSelect(event: any) {
    this.totalPriceWithAdditional = 0;
    this.selectedAdditionalService.push(event.data);
    this.totalPriceWithAdditional += event.data.dailyPrice
    this.allAdditionServiceIds.push(event.data.id)
    this.messageService.add({ severity: 'info', summary: 'Product Selected', detail: event.data.name });
  }

  getAllAdditionalService() {
    this.additionalService.getAllAdditional().subscribe(response => {
      this.allAdditionalService = response.data;
    })
  }

  calcRentDate() {
    let deliveryDate: Date = new Date(this.otherModel["currentModel"].deliveryDate);
    let rentedDate: Date = new Date(this.otherModel["currentModel"].rentedDate);
    let rentTime = deliveryDate.getTime() - rentedDate.getTime()
    this.numberOfRentedDays = rentTime / (1000 * 3600 * 24)
  }

  checkCity(): boolean {

    if (this.otherModel["currentModel"].deliveryCity != null &&
      this.otherModel["currentModel"].rentedCity != this.otherModel["currentModel"].deliveryCity) {
      this.addCityPrice = 500;
      return true
    }
    this.addCityPrice = 0
    return false
  }
}
