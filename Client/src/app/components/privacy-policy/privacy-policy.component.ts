import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { PrivacyPolicyService } from 'src/app/services/privacyPolicy/privacy-policy.service';

@Component({
  selector: 'app-privacy-policy',
  templateUrl: './privacy-policy.component.html',
  styleUrls: ['./privacy-policy.component.scss']
})
export class PrivacyPolicyComponent implements OnInit {
  isLoaded: boolean;
  loadedLang: string = "";
  privacyPolicies: any;

  constructor(private _translate: TranslateService, private _privacyPolicyService: PrivacyPolicyService) { }

  ngOnInit(): void {
    setInterval(() => {
      const lang = this._translate.getDefaultLang();
      if (!this.isLoaded || this.loadedLang !== lang)
        this.loadData(lang)
    }, 500)
  }

  loadData(lang: string) {
    this._privacyPolicyService.ListPrivacyPolicy(lang).subscribe(data => {
      this.privacyPolicies = data;
      this.isLoaded = true;
      this.loadedLang = lang;
    })
  }
}
