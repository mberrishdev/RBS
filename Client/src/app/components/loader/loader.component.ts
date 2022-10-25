import { Component, OnInit } from '@angular/core';
import { delay } from 'rxjs';
import { LoadingService } from 'src/app/services/loading/loading.service';

@Component({
  selector: 'app-loader',
  templateUrl: './loader.component.html',
  styleUrls: ['./loader.component.scss']
})
export class LoaderComponent implements OnInit {
  loading = true;

  constructor(private _loading: LoadingService) { }

  ngOnInit(): void {
    this.listenToLoading();
  }

  listenToLoading(): void {
    this._loading.loadingSub
      .pipe(delay(0))
      .subscribe((loading) => {
        this.loading = loading;
      });
  }

}
