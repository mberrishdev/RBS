import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { AuthResponse } from '../models/AuthResponse'
@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }

  //Auth

  isAuthenticated(): boolean {
    try {
      const result = localStorage.getItem('token') !== null;
      return result;
    } catch (e) {
      return false;
    }
  }

  clearAuthData() {
    localStorage.removeItem('userId');
    localStorage.removeItem('userName');
    localStorage.removeItem('token');
    localStorage.removeItem('expires');
    localStorage.removeItem('refreshToken');
  }

  saveAuthData(data: AuthResponse) {
    localStorage.setItem('userId', (data.userId).toString());
    localStorage.setItem('name', 'mikheil');
    localStorage.setItem('surName', 'berishvili');
    localStorage.setItem('userName', data.userName);
    localStorage.setItem('token', data.token);
    localStorage.setItem('refreshToken', data.refreshToken);
    localStorage.setItem('expires', (data.expires).toString());
  }

  auth(dt: any) {
    this.http.post(environment.baseUrl + `Authorization/Login`, dt).subscribe(data => {
      if (data) {
        console.log(data);

        this.saveAuthData(data as AuthResponse);
      }
    })
  }

  Register(dt: any) {
    console.log(dt);
  }

}
