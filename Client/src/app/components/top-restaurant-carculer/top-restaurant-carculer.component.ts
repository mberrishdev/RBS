import { Component, OnInit } from '@angular/core';
import { RestaruantService } from 'src/app/services/restaurantServices/restaruant.service';
import { Restaurant } from '../../models/models';

@Component({
  selector: 'app-top-restaurant-carculer',
  templateUrl: './top-restaurant-carculer.component.html',
  styleUrls: ['./top-restaurant-carculer.component.scss']
})
export class TopRestaurantCarculerComponent implements OnInit {
  restaurants: Restaurant[] | any;
  responsiveOptions;

  constructor(private rApiService: RestaruantService) {
    this.responsiveOptions = [
      {
        breakpoint: '1024px',
        numVisible: 3,
        numScroll: 3
      },
      {
        breakpoint: '768px',
        numVisible: 2,
        numScroll: 2
      },
      {
        breakpoint: '560px',
        numVisible: 1,
        numScroll: 1
      }
    ];
  }

  ngOnInit() {
    this.rApiService.GetTopRestaurants().subscribe(rs => {
      this.restaurants = rs;
      console.log(this.restaurants);
    });
    console.log(this.restaurants);
  }

}
