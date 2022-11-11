import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { PanoViewer } from '@egjs/view360';

@Component({
  selector: 'app-three-sixty-image',
  templateUrl: './three-sixty-image.component.html',
  styleUrls: ['./three-sixty-image.component.scss']
})
export class ThreeSixtyImageComponent implements OnInit {

  @ViewChild('360viewer', { static: false }) viewer: any;

  @Input() imageSrc: string = '';

  constructor() { }

  ngAfterViewInit(): void {
    new PanoViewer(this.viewer.nativeElement, {
      image: this.imageSrc,
    });
  }

  ngOnInit(): void {
  }

}
