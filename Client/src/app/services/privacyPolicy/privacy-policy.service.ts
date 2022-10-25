import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PrivacyPolicyService {

  constructor(private http: HttpClient) { }

  ListPrivacyPolicy(lang: string) {
    return this.http.get(environment.baseUrl + 'PrivacyPolicies/' + lang);
  }
}
