import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class RestaruantService {

  constructor(private http: HttpClient) { }

  GetRestaurantMainInformation(id: number)
  {
    return this.http.get(environment.baseUrl + 'Restaurant/MainInformation/' + id);
  }
  GetTopRestaurants() {
    return this.http.get(environment.baseUrl + 'Restaurant/ListOfTopResturants');
  }
  GetRestaurantTopImages(id: number) {
    return this.http.get(environment.baseUrl + 'Restaurant/RestaurantTopImages/' + id);
  }

  Search()
  {
    const params = new HttpParams()
        .set('restaurant', 'ss')
    return this.http.get(environment.baseUrl +'Restaurant',{params})
  }
}
