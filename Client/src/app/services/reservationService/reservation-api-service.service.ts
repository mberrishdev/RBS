import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ReservationApiServiceService {

  constructor(private http: HttpClient) { }
  Reservation(dt: any) {
    return this.http.post(environment.baseUrl + "Reservation", dt);
  }
}
