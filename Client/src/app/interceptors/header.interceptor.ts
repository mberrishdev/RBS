import { Injectable } from "@angular/core";
import {
  HttpEvent,
  HttpRequest,
  HttpHandler,
  HttpInterceptor,
  HttpHeaders
} from "@angular/common/http";
import { Observable } from "rxjs";
import { TranslateService } from "@ngx-translate/core";

@Injectable()
export class HeaderInterceptor implements HttpInterceptor {
  constructor(private translate: TranslateService) { }
  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    console.warn("HeaderInterceptor");

    return next.handle(this.attachLang(req));
  }

  private attachLang(req: HttpRequest<any>) {
    const lang = this.translate.getDefaultLang();
    return req.clone({
      headers: new HttpHeaders().set(
        'Accept-Language',
        lang
      ),
    });
  }
}
