import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ErrorHelperService {

  public msgs: any[] = [];
  public occurredError: boolean;
  public destroyed$ = new Subject<void>();
  public errors: string[] = [];

  constructor() {}

  showMessage(error: string[]): void {
    if (error) {
      error.forEach(m => {
        this.msgs.push(m);
      });
    }
    console.log(error);

    this.errors = this.msgs.filter(data => !!data);
  }

  checkError(error: string): void {
    if (error) {
      this.occurredError = true;
    } else {
      this.occurredError = false;
    }
  }
}
