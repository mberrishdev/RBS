import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class MenuApiServiceService {

  constructor(private http: HttpClient) { }

  GetMenuTypes(restaurantId: number) {
    return this.http.get(environment.baseUrl + 'menu/GetMenuTypes/' + restaurantId);
  }

  GetMenuFullData(restaurantId: number, subMenuId: number) {
    return this.http.get(environment.baseUrl + 'Menu/GetMenuFullData/' + restaurantId + '/' + subMenuId);
  }
}
