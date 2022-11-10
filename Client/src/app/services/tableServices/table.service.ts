import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { TableImageModel, TableModel } from 'src/app/models/models';

@Injectable({
  providedIn: 'root'
})
export class TableService {

  constructor(private http: HttpClient) { }

  GetTableByRestaurantId(restaurantId: number): Observable<TableModel[]> {
    return this.http.get<TableModel[]>(environment.baseUrl + 'Table/GetTableByRestaurantId/' + restaurantId)
  }

  GetTableImages(tableId: number): Observable<TableImageModel[]> {
    return this.http.get<TableImageModel[]>(environment.baseUrl + 'Table/GetTableImages/' + tableId)
  }
}
