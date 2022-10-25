import { Component, OnInit, Input } from '@angular/core';
import { ReviewApiServiceService } from 'src/app/services/reviewServices/review-api-service.service';
import { ReviewFullModel } from '../models/models';

@Component({
  selector: 'app-restaurant-reviews-section',
  templateUrl: './restaurant-reviews-section.component.html',
  styleUrls: ['./restaurant-reviews-section.component.scss']
})
export class RestaurantReviewsSectionComponent implements OnInit {
  @Input() restaurantId: number = 0;

  max = 5;
  restaurantRate = 3.4;
  isReadonly = false;

  isLoaded: Boolean = false;

  reviewFullModel: ReviewFullModel | any;

  reviewerCount: number = 0;;
  foodReview = 2.4;
  serviceReview = 2.4;

  constructor(private reviewApiService: ReviewApiServiceService) {
  }

  ngOnInit(): void {
    this.loadReviews();
  }

  loadReviews() {
    if (!this.isLoaded) {
      this.reviewApiService.GetRestaurantReviews(this.restaurantId).subscribe(r => {
        this.reviewFullModel = r;
        this.reviewerCount = this.reviewFullModel.reviews.length;
        this.isLoaded = true;
      });
    }
  }

  GetDate(dateTime: Date) {
    const _date = new Date(dateTime);
    return `${_date.getFullYear()}-${_date.getMonth()}-${_date.getDate()}`
  }

}
