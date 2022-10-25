import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }

  // getData() {
  //   let params = new HttpHeaders();
  //   return this.http.get(environment.baseUrl);

  // }

  // postData(dt: any) {
  //   return this.http.post(`https://jsonplaceholder.typicode.com/users`, dt);
  // }
}
