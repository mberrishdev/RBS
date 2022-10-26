import { Component, OnInit, Input } from '@angular/core';
import { ImageApiServiceService } from 'src/app/services/imageServices/image-api-service.service';
import { ImageType } from '../enums/enums';
import { Image } from '../models/models';

@Component({
  selector: 'app-restaurant-image-section',
  templateUrl: './restaurant-image-section.component.html',
  styleUrls: ['./restaurant-image-section.component.scss']
})

export class RestaurantImageSectionComponent implements OnInit {
  @Input() restaurantId: number = 0;

  isLoaded: Boolean = false;
  loadedImageType: number = 0;
  isCountGreatherThanOrEquel5: Boolean = false;
  isCountGreatherThan5: Boolean = false;
  photoesCount: number = 0;
  imageType: ImageType = ImageType.All;
  modeLoadedCount: number = 0;
  imageList: Image[] | any = [];
  imageWhichIsShowList: Image[] = [];
  isMoreImagePopupOpen: boolean = false
  imageInSinglePage: number = 5;

  constructor(private imageApiService: ImageApiServiceService) {
  }

  ngOnInit(): void {
    this.loadImage(ImageType.All);
  }

  loadImage(type: number) {
    this.isCountGreatherThan5 = false;
    if (!this.isLoaded || this.loadedImageType !== type) {
      this.isLoaded = false;
      this.imageApiService.GetRestaurantImages(this.restaurantId, type).subscribe(i => {
        this.imageList = i;
        this.photoesCount = this.imageList.length
        this.isLoaded = true;

        this.imageWhichIsShowList = this.imageList;
        if (this.photoesCount > this.imageInSinglePage) {
          this.imageWhichIsShowList = this.imageList.slice(0, this.imageInSinglePage);
          this.isCountGreatherThan5 = true;
          this.modeLoadedCount = this.photoesCount - this.imageInSinglePage;
        }
        if (this.photoesCount >= this.imageInSinglePage) {
          this.isCountGreatherThanOrEquel5 = true
        }

        this.loadedImageType = type;
      });
    }
  }
}
