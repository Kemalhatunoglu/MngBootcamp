import { Component, OnInit } from '@angular/core';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {

  allCategories: MenuItem[] = [
    { label: "Sedan", icon: "assets/image/category/sedan.png", routerLink: "sedan",tooltip:"sedan",tooltipPosition:"right" },
    { label: "Hatchback", icon: "assets/image/category/hatchback.png", routerLink: "hatchback" },
    { label: "Suv", icon: "assets/image/category/suv.png", routerLink: "suv" },
    { label: "Karavan", icon: "assets/image/category/caravan.png", routerLink: "caravan" }
  ];
  constructor() { }

  dockItems: MenuItem[];

  ngOnInit(): void {

  }

}
