import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class TersmAndConditionsService {

  constructor(private http: HttpClient) { }

  ListTermAndCondition(lang: string) {
    return this.http.get(environment.baseUrl + 'TermsAndConditions/' + lang);
  }
}
