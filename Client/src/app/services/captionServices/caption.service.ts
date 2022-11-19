import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Caption } from 'src/app/models/caption';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CaptionService {

  _captions: Caption[];
  constructor(private http: HttpClient) { }

  LoadCaptions(languageId: any) {
    this.http.get<Caption[]>(environment.baseUrl + "Captions/" + languageId).subscribe(x => {
      this._captions = x
    });
  }

  GetCaptionByKey(key: string): string {
    const value = this._captions.find(x => x.key == key)
    if (value)
      return value.value;
    return key;
  }
}
