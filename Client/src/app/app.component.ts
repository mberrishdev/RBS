import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { Language } from './models/models';
import { CaptionService } from './services/captionServices/caption.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent implements OnInit {
  title = 'RBS.Front.Angular';
  userName: string | any;
  name: string | any;
  surName: string | any;
  imageAddress: string | any;
  languages: Language[] | any;

  constructor(private captionSerice: CaptionService, private _translate: TranslateService) {
    this.loadCaptions();
  }
  ngOnInit() {
    this.loadUserInfo();
  }

  onMenuClick($event: any) {
  }

  loadUserInfo() {
    const getUserName = localStorage.getItem('userName');
    this.userName = getUserName ? getUserName : '';
    const getName = localStorage.getItem('name');
    this.name = getName ? getName : '';
    const getSurName = localStorage.getItem('surName');
    this.surName = getSurName ? getSurName : '';
    this.imageAddress = "https://i.ibb.co/jJYm14r/1648196784996.jpg";
  }

  loadCaptions() {
    //todo change language
    const lang = this._translate.getDefaultLang();
    var langId = localStorage.getItem(lang);
    if (langId)
      this.captionSerice.LoadCaptions(langId);
  }
}
