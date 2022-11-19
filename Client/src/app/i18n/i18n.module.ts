import { NgModule } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { TranslateLoader, TranslateModule, TranslateService } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';

@NgModule({
  imports: [
    HttpClientModule,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: translateLoaderFactory,
        deps: [HttpClient]
      }
    }),
  ],
  exports: [TranslateModule]
})
export class I18nModule {
  constructor(translate: TranslateService) {
    localStorage.setItem('ka', '1');
    localStorage.setItem('en', '2');
    
    translate.addLangs(['en', 'ka']);
    const browserLang = translate.getBrowserLang();
    let lang = browserLang?.match(/en|ka/) ? browserLang : 'en';
    lang = 'ka';
    translate.use(lang);
    translate.setDefaultLang(lang)
    translate.reloadLang(lang);
  }
}

export function translateLoaderFactory(httpClient: HttpClient) {
  return new TranslateHttpLoader(httpClient);
}
