import { Component, OnInit } from '@angular/core';
import { MenuItem, PrimeIcons } from 'primeng/api';
import { AuthService } from 'src/app/auths/auth-service/auth.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  items: MenuItem[];
  isAuthenticated: boolean = false;

  constructor(private authService: AuthService) { }

  ngOnInit(): void {

    this.authService.user.subscribe(user => {
      this.isAuthenticated = !user ? false : true;
    });

    this.getNavBarMenu();
  }

  getNavBarMenu() {
    this.items = [
      {
        label: 'Rezervasyonlar',
        items: [
          { label: 'Rezervasyon Oluştur', icon: 'pi pi-fw pi-trash', routerLink: "rental/create" },
          { label: 'Rezervasyon İptal', icon: 'pi pi-fw pi-trash', routerLink: "rental/cancel" }
        ]
      },
      {
        label: 'Kampanyalar',
        items: [
          { label: 'Mng Elite', icon: 'pi pi-fw pi-trash' },
          { label: 'Mng Prime', icon: 'pi pi-fw pi-refresh' },
          { label: 'Mng Platin', icon: 'pi pi-fw pi-refresh' }
        ]

      },
      {
        label: 'Ofisler',
        items: [
          { label: 'Ankara', icon: 'pi pi-fw pi-trash' },
          { label: 'İstanbul', icon: 'pi pi-fw pi-refresh' }
        ]

      },
      {
        label: 'Filo',
        items: [
          { label: 'Sedan', icon: 'pi pi-fw pi-trash' },
          { label: 'Hatchback', icon: 'pi pi-fw pi-refresh' },
          { label: 'Suv', icon: 'pi pi-fw pi-refresh' },
          { label: 'Lüks', icon: 'pi pi-fw pi-refresh' },
        ]
      },
      {
        label: 'Karavan',
        routerLink: "van"
      },
      {
        label: 'İletişim',
        routerLink: "contact"
      }
    ];
  }


  logout() {
    this.authService.logout();
  }
}
