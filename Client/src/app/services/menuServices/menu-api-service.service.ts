import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Menu } from 'src/app/models/models';

@Injectable({
  providedIn: 'root'
})
export class MenuApiServiceService {

  constructor(private http: HttpClient) { }

  GetMenuByRestaurantId(restaurantId: number): Observable<Menu> {
    return this.http.get<Menu>(environment.baseUrl + 'menu/GetMenuByRestaurantId/' + restaurantId);
  }

  GetMenuFullData(restaurantId: number, subMenuId: number): Observable<Menu> {
    return this.http.get<Menu>(environment.baseUrl + 'Menu/GetMenuFullData/' + restaurantId + '/' + subMenuId);
  }
}
