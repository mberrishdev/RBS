import { Renderer2, Component, Inject, Input, OnInit } from '@angular/core';
import { AuthService } from '../../auth/services/auth.service';
import { DOCUMENT } from '@angular/common';
import { Language } from 'src/app/models/models';
import { ActivatedRoute, Params } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { CaptionService } from 'src/app/services/captionServices/caption.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {

  topbarItemClick!: boolean;
  displaySearchPopup: boolean;

  activeTopbarItem: any;

  @Input() userName: string = '';
  @Input() name: string = '';
  @Input() surName: string = '';
  @Input() imageAddress: string = '';
  checked: boolean;
  selectedLanguage: Language;
  displayLanguageDialog: boolean;

  notificationsList: Array<{ text: string, subText: string }> = [
    { text: 'Sentence 1', subText: "" },
    { text: 'Sentence 2', subText: "" },
    { text: 'Sentence 3', subText: "" },
    { text: 'Sentenc4 ', subText: "" },
  ];

  constructor(
    private translateService: TranslateService,
    public authService: AuthService,
    private _renderer2: Renderer2,
    private _captionSerice: CaptionService,
    @Inject(DOCUMENT) private _document: Document
  ) { }

  ngOnInit(): void {

    let script = this._renderer2.createElement('script');
    script.text = `
        {

        }
    `;

    this._renderer2.appendChild(this._document.body, script);
  }

  onTopbarItemClick(event: any, item: any) {

    // this.authService.isAuthenticated();
    this.topbarItemClick = true;

    if (this.activeTopbarItem === item) {
      this.activeTopbarItem = null;
    } else {
      this.activeTopbarItem = item;
    }

    // if (item.className === 'search-item topbar-item') {
    //   this.search = !this.search;
    //   this.searchClick = !this.searchClick;
    // }

    event.preventDefault();
  }

  openPopup() {
    this.displaySearchPopup = true;

  }
  onTopbarSubItemClick(event: any) {
    event.preventDefault();
  }

  logOut() {
    this.authService.clearAuthData();
  }

  ChangeLang(lang: string) {

    var langId = localStorage.getItem(lang);
    this._captionSerice.LoadCaptions(langId);
    this.translateService.use(lang);
    this.translateService.setDefaultLang(lang)
    this.translateService.reloadLang(lang);

    this.displayLanguageDialog = false;
  }

  showLanguageDialog() {
    this.displayLanguageDialog = true;
  }
}
