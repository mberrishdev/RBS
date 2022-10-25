import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ImageApiServiceService {

  constructor(private http: HttpClient) { }

  GetRestaurantImages(restaurantId: number, imageTpye: number) {
    return this.http.get(environment.baseUrl + 'Image/GetRestaurantImages/' + restaurantId + '/' + imageTpye);
  }

  GetRestaurantTopImage(restaurantId: number) {
    return this.http.get(environment.baseUrl + 'Image/GetRestaurantTopImage/' + restaurantId);
  }
}
