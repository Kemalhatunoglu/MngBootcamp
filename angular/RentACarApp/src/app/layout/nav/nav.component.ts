import { Component, OnInit } from '@angular/core';
import { MenuItem } from 'primeng/api';
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
        label: 'Rental',
        items: [
          {
            label: 'Araçlar',
            icon: 'pi pi-fw pi-plus',
            items: [
              { label: 'Otomobil', routerLink: 'car' },
              { label: 'Karavan' },
            ]
          },
          { label: 'Open' },
          { label: 'Quit' }
        ]
      },
      {
        label: 'Kullanıcılar',
        items: [
          { label: 'Delete', icon: 'pi pi-fw pi-trash' },
          { label: 'Refresh', icon: 'pi pi-fw pi-refresh' }
        ],
      }
    ];
  }

}
