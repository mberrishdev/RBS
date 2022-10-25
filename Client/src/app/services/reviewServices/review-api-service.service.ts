import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root'
})
export class ReviewApiServiceService {

  constructor(private http: HttpClient) { }

  GetRestaurantReviews(restaurantId: number)
  {
    return this.http.get(environment.baseUrl + 'Review/GetRestaurantReviews/' + restaurantId);
  }
}
