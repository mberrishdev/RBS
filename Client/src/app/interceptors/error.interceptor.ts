import {
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
  HttpResponse,
  HttpErrorResponse
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { ErrorHelperService } from '../services/errorHelper/error-helper.service';


@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  constructor(private router: Router, private errorService: ErrorHelperService) {}

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(req).pipe(
      map((event: HttpEvent<any>) => {
        if (event instanceof HttpResponse) {
          if (!(event.body).success || (event.body).error) {
            // this.errorService.checkError(event.body.error);
            // this.errorService.showMessage(event.body.error);
          }
        }
        return event;
      }),
      // catchError((errorResponse: HttpErrorResponse) => {
      //   if (errorResponse.status === 401) {
      //     if (this.router.url.startsWith('/login')) {
      //       throwError(errorResponse.statusText);
      //     } else {
      //       this.errorService.checkError('unauthorized', true);
      //       this.errorService.showMessage('თქვენი სესია ამოიწურა, გთხოვთ ხელახლა შეხვიდეთ სისტემაში');
      //     }
      //   } else if (errorResponse.status === 403) {
      //     if (this.router.url.startsWith('/login')) {
      //       throwError(errorResponse.statusText);
      //     } else {
      //       this.errorService.checkError('forbidden');
      //       this.errorService.showMessage('თქვენ არ გაქვთ ოპერაციის განხორციელების უფლება');
      //     }
      //   } else if (errorResponse.status === 409) {
      //     if (this.router.url.startsWith('/login')) {
      //       throwError(errorResponse.statusText);
      //     } else {
      //       this.errorService.checkError('forbidden');
      //       this.errorService.showMessage(errorResponse.error.detail);
      //     }
      //   } else if (errorResponse.error) {
      //     if (
      //       errorResponse.error.errors &&
      //       errorResponse.error.errors instanceof Array &&
      //       errorResponse.error.errors.length > 0
      //     ) {
      //       // for (const errorMessage of errorResponse.error.errors) {
      //       // }
      //     }
      //   }
      catchError((errorResponse: HttpErrorResponse) => {
        if (errorResponse.status >= 400) {
          if (errorResponse.error.detail) {
            this.errorService.showMessage([errorResponse.error.message]);
          } else if (errorResponse.error.message) {
            const objKeys = Object.keys(errorResponse.error.errors);
            this.errorService.showMessage(errorResponse.error.message);
          }
          this.errorService.checkError('error');
        }
        return throwError(errorResponse);
      })
    );
  }
}
