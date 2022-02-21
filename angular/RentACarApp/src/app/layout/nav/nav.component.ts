import { Component, OnInit } from '@angular/core';
import { MenuItem, PrimeIcons } from 'primeng/api';
import { AuthService } from 'src/app/auths/auth-service/auth.service';
import { CityListModel } from 'src/app/home/entity-model/City/CityListModel';
import { CityModel } from 'src/app/home/entity-model/City/CityModel';
import { CityService } from 'src/app/home/feature/services/city.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  items: MenuItem[];
  isAuthenticated: boolean = false;
  citiesModel: CityModel[] = [];
  cityItem: MenuItem[];

  isShowRentalModal: boolean = false;

  constructor(
    private authService: AuthService,
    private cityService: CityService
  ) { }

  ngOnInit(): void {

    this.authService.user.subscribe(user => {
      this.isAuthenticated = !user ? false : true;
    });

    this.getNavBarMenu();
    this.getAllCity()
  }

  showRentalModal(rental: any) {
    this.isShowRentalModal = true;
  }

  getNavBarMenu() {
    this.items = [
      {
        label: 'Ana Sayfa',
        routerLink: "home"
      },
      {
        label: 'Rezervasyonlar',
        command: rental => this.showRentalModal(rental)
      },
      {
        label: 'Kampanyalar',
        items: [
          { label: 'Mng Elite', icon: PrimeIcons.THUMBS_UP },
          { label: 'Mng Prime', icon: PrimeIcons.THUMBS_UP },
          { label: 'Mng Platin', icon: PrimeIcons.THUMBS_UP }
        ]

      },
      {
        label: 'Ofisler',
        items: [
          { label: 'Ankara', icon: PrimeIcons.MAP_MARKER, routerLink: "cities" },
          { label: 'İstanbul', icon: PrimeIcons.MAP_MARKER, routerLink: "cities" }
        ]

      },
      {
        label: 'Filo',
        items: [
          { label: 'Sedan', icon: PrimeIcons.ANGLE_DOUBLE_RIGHT },
          { label: 'Hatchback', icon: PrimeIcons.ANGLE_DOUBLE_RIGHT },
          { label: 'Suv', icon: PrimeIcons.ANGLE_DOUBLE_RIGHT },
          { label: 'Lüks', icon: PrimeIcons.ANGLE_DOUBLE_RIGHT },
        ]
      },
      {
        label: 'Karavan',
        routerLink: "van"
      },
      {
        label: 'İletişim',
        routerLink: "contact"
      },
      {
        label: 'Admin',
        items: [
          { label: 'Veri Girişi', routerLink: 'feature', icon: PrimeIcons.ANGLE_DOUBLE_RIGHT },
        ],

      }
    ];
  }

  logout() {
    this.authService.logout();
  }

  getAllCity() {
    this.cityService.getAllCities(0, 10).subscribe(response => {
      if (response.success) {
        this.citiesModel = response.data.items;
      }
    })
  }
}
