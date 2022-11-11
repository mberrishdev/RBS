import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RestaruantService } from 'src/app/services/restaurantServices/restaruant.service';
import { Restaurant } from '../../models/models';

@Component({
  selector: 'app-restaurant',
  templateUrl: './restaurant.component.html',
  styleUrls: ['./restaurant.component.scss']
})
export class RestaurantComponent implements OnInit {
  isLoaded: boolean = false;
  restaurantId: number = 0;
  max = 5;
  isReadonly = false;

  restaurant: Restaurant | any;

  constructor(private router: Router ,private route: ActivatedRoute, private restaurantApiService: RestaruantService) {

  }

  scroll(el: HTMLElement) {
    this.router.navigate( [ ], { fragment: el.className } )
    el.scrollIntoView({ behavior: 'smooth' });
  }

  ngOnInit() {
    this.restaurant = { name: "HB", restaurantRate: 4.3, reviewCount: 123, averagePrice: "$40 and over", restaurantMainType: "Qartulia bicho", description: "SAfasf", address: 'Tbilisi,Georgia' }
    var id = this.route.snapshot.paramMap.get("restaurantId");
    if (id != null) {
      this.restaurantId = parseInt(id);
    }

    this.loadRestaurantData();
  }

  loadRestaurantData() {
    if (!this.isLoaded) {
      this.restaurantApiService.GetRestaurantMainInformation(this.restaurantId).subscribe(r => {
        this.restaurant = r;
        this.isLoaded = true;
      });
    }
  }
}
