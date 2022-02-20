import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {

  comment: string = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Inventore sed consequuntur error repudiandae numquam deserunt quisquam repellat libero asperiores earum nam nobis, culpa ratione quam perferendis esse, cupiditate neque quas!"
  constructor() { }

  backcolor = { 'background': 'white', 'color': '#071426', 'margin-bottom': '8px' }
  //cardback = { 'background': 'white', 'color': '#071426', 'margin-bottom': '8px' }
  offers: any[] = [
    {
      id: 1,
      name: "ZUBİZU",
      description: "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Inventore sed consequuntur error repudiandae numquam deserunt quisquam repellat libero asperiores earum nam nobis",
      img: "assets/image/offers/1.jpg"
    },
    {
      id: 2,
      name: "BMW 1.16i OTOMATİK 649 TL - TOYOTA HILUX 679 TL",
      description: "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Inventore sed consequuntur error repudiandae numquam deserunt quisquam repellat libero asperiores earum nam nobis",
      img: "assets/image/offers/2.jpg"
    },
    {
      id: 3,
      name: "ELEKTRİKLİ ARAÇ DENEYİMİ SİZİ BEKLİYOR",
      description: "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Inventore sed consequuntur error repudiandae numquam deserunt quisquam repellat libero asperiores earum nam nobis",
      img: "assets/image/offers/3.jpg"
    },
  ]

  ngOnInit(): void {
  }

}
