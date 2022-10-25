import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AdditionalInformationApiServiceService {

  constructor(private http: HttpClient) { }

  GetAdditionalInformation(restaurantId: number) {
    return this.http.get(environment.baseUrl + 'AdditionalInformation/GetAdditionalInformation/' + restaurantId);
  }
}
