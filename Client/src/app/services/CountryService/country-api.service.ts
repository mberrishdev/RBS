import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CountryApiService {

  constructor(private http: HttpClient) { }

  ListOfCountry() {
    return this.http.get(environment.baseUrl + 'Country/ListOfCountry/');
  }
}
