import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { CarDetailModel } from '../../entity-model/car/carDetailModel';

@Component({
  selector: 'app-car-detail',
  templateUrl: './car-detail.component.html',
  styleUrls: ['./car-detail.component.css']
})
export class CarDetailComponent implements OnInit {

  @Input() selectedCarDetail: CarDetailModel = null;
  @Input() displayModal: boolean = false;
  @Output() displayModalChange = new EventEmitter<boolean>();

  constructor() { }

  ngOnInit(): void {

  }


  hideDialog() {
    this.displayModal = false
    this.displayModalChange.emit(this.displayModal);
  }
}
