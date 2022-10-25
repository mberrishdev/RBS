import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { TersmAndConditionsService } from 'src/app/services/tersmAndConditions/tersm-and-conditions.service';

@Component({
  selector: 'app-terms-and-conditions',
  templateUrl: './terms-and-conditions.component.html',
  styleUrls: ['./terms-and-conditions.component.scss']
})
export class TermsAndConditionsComponent implements OnInit {
  isLoaded: boolean;
  loadedLang: string = "";
  termsAndConditions: any;

  constructor(private translate: TranslateService, private termsAndConditionService: TersmAndConditionsService) { }

  ngOnInit(): void {

    // this.loadData("ka")
    setInterval(() => {
      const lang = this.translate.getDefaultLang();
      if (!this.isLoaded || this.loadedLang !== lang)
        this.loadData(lang)
    }, 500)
  }

  loadData(lang: string) {
    this.termsAndConditionService.ListTermAndCondition(lang).subscribe(data => {
      this.termsAndConditions = data;
      this.isLoaded = true;
      this.loadedLang = lang;
    })
  }
}
