import { Component, OnInit, Input } from '@angular/core';
import { AdditionalInformationModel } from '../models/models';
import { AdditionalInformationApiServiceService } from '../../services/additionalInformationService/additional-information-api-service.service';

@Component({
  selector: 'app-restaurant-additional-information',
  templateUrl: './restaurant-additional-information.component.html',
  styleUrls: ['./restaurant-additional-information.component.scss']
})
export class RestaurantAdditionalInformationComponent implements OnInit {
  @Input() restaurantId: number = 0;

  isAdditionalInformationLoaded: Boolean = false;
  additionalInformations: AdditionalInformationModel[] | any = [];

  constructor(private additionalInformationApiService: AdditionalInformationApiServiceService) { }

  ngOnInit(): void {
    this.loadAdditionalInformation();
  }

  loadAdditionalInformation() {
    if (!this.isAdditionalInformationLoaded) {
      this.additionalInformationApiService.GetAdditionalInformation(this.restaurantId).subscribe(ai => {
        this.additionalInformations = ai;
        this.isAdditionalInformationLoaded = true;
      });
    }
  }
}
