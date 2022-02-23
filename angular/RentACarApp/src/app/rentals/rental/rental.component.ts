import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { CityModel } from 'src/app/home/entity-model/City/CityModel';
import { BrandService } from 'src/app/home/feature/services/brand.service';
import { CityService } from 'src/app/home/feature/services/city.service';

@Component({
  selector: 'app-rental',
  templateUrl: './rental.component.html',
  styleUrls: ['./rental.component.css']
})
export class RentalComponent implements OnInit {

  @Input() displayModal = false;
  @Output() displayModalChange = new EventEmitter<boolean>();

  allCity: CityModel[] = [];
  selectedRentedCit: number = 1;
  selectedDeliveryCity: number = 1;
  isSameCity: boolean = false;
  rentedCity: CityModel;
  deliveryCity: CityModel;
  rentedDate: Date = new Date();
  deliveryDate: Date = new Date();

  rentalLocationForm = new FormGroup({
    rentedCity: new FormControl(),
    deliveryCity: new FormControl(),
    rentedDate: new FormControl(),
    deliveryDate: new FormControl(),
    isSameCity: new FormControl()
  })

  constructor(
    private cityService: CityService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.getallCities();
  }

  getallCities() {
    this.cityService.getAllCities().subscribe(res => {
      this.allCity = res.data.items;
    })
  }

  createRental() {
    this.router.navigate(["rental/create"],
      { state: { currentModel: this.rentalLocationForm.value }, skipLocationChange: true });
    this.displayModal = false;
  }

  hideDialog() {
    this.displayModal = false;
    this.displayModalChange.emit(this.displayModal);
  }

}
