import { Component, OnDestroy, OnInit } from '@angular/core';
import { ErrorHelperService } from 'src/app/services/errorHelper/error-helper.service';

@Component({
  selector: 'app-error-modal',
  templateUrl: './error-modal.component.html',
  styleUrls: ['./error-modal.component.scss']
})

export class ErrorModalComponent implements OnInit, OnDestroy {

  display = true;

  constructor(public errorHelper: ErrorHelperService) { }

  ngOnInit() {
  }

  onHide() {
    this.errorHelper.msgs = [];
    this.errorHelper.occurredError = false;
  }

  ngOnDestroy() {
    this.errorHelper.destroyed$.next();
    this.errorHelper.destroyed$.complete();
  }
}
