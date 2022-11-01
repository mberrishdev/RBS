import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { RestaurantOrderType } from 'src/app/enums/enums';
import { RestaruantService } from 'src/app/services/restaurantServices/restaruant.service';
import { RestaurantSearchModel } from '../../models/models';

interface RestaurantSortTypeInterface {
  sortType: string,
  id: number
}

@Component({
  selector: 'app-restaurant-list',
  templateUrl: './restaurant-list.component.html',
  styleUrls: ['./restaurant-list.component.scss']
})
export class RestaurantListComponent implements OnInit {

  searchedRestaruants: RestaurantSearchModel[] = [];
  keyword: string;
  sortOptions: RestaurantSortTypeInterface[];
  selectedSortOption: RestaurantSortTypeInterface = { "id": RestaurantOrderType.None, "sortType": RestaurantOrderType[RestaurantOrderType.None] };

  constructor(private restaurantService: RestaruantService, private route: ActivatedRoute) {
  }

  ngOnInit(): void {

    this.sortOptions = [
      { "id": RestaurantOrderType.None, "sortType": RestaurantOrderType[RestaurantOrderType.None] },
      { "id": RestaurantOrderType.Newest, "sortType": RestaurantOrderType[RestaurantOrderType.Newest] },
      { "id": RestaurantOrderType.Featured, "sortType": RestaurantOrderType[RestaurantOrderType.Featured] },
      { "id": RestaurantOrderType.Nearest, "sortType": RestaurantOrderType[RestaurantOrderType.Nearest] },
      { "id": RestaurantOrderType.HigestRated, "sortType": RestaurantOrderType[RestaurantOrderType.HigestRated] },
    ]

    this.route.queryParams.subscribe(params => {
      this.keyword = params.keyword;
    });

    this.LoadRestaurants(this.selectedSortOption.id);
  }

  LoadRestaurants(sortOptionId: number) {
    this.restaurantService.Search(sortOptionId).subscribe(data => {
      this.searchedRestaruants = data;
    });
  }

  OrderByOnChange(event: Event) {
    if (this.selectedSortOption == null) {
      this.LoadRestaurants(RestaurantOrderType.None)
    } else
      this.LoadRestaurants(this.selectedSortOption.id)

  }

  GetTime(time: any) {
    return new Date(time).toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' });
  }

}
