import { Component, OnInit } from '@angular/core';
import { RestaruantService } from 'src/app/services/restaurantServices/restaruant.service';

@Component({
  selector: 'app-restaurant-list',
  templateUrl: './restaurant-list.component.html',
  styleUrls: ['./restaurant-list.component.scss']
})
export class RestaurantListComponent implements OnInit {

  searchedRestaruants : any;
  constructor(private restaurantService : RestaruantService) { }

  ngOnInit(): void {
    console.log("list is opend");

    this.restaurantService.Search().subscribe(data=>{

      this.searchedRestaruants = data;

      console.log(this.searchedRestaruants);


    });
  }

  GetTime(time:any)
  {
    return new Date(time).toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' });
  }

}
