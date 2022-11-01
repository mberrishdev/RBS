import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { Address, Restaurant } from '../../models/models';

declare var google: any;

@Component({
  selector: 'app-restaurant-reservation-section',
  templateUrl: './restaurant-reservation-section.component.html',
  styleUrls: ['./restaurant-reservation-section.component.scss']
})

export class RestaurantReservationSectionComponent implements OnInit {
  @Input() restaurantId: number = 0;
  @Input() restaurantName: string;
  @Input() address: Address | any;
  @Input() restaurant: Restaurant;
  options: any;
  display: any;
  center: google.maps.LatLngLiteral = {
    lat: 41.726199,
    lng: 44.7345909
  };
  zoom = 4;

  overlays: any[] | any;

  isLoaded: Boolean = true;

  constructor(private router: Router) { }

  ngOnInit() {
    this.options = {
      center: { lat: 36.890257, lng: 30.707417 },
      zoom: 12
    };
  }
  moveMap(event: google.maps.MapMouseEvent) {
    if (event.latLng != null) this.center = (event.latLng.toJSON());
  }
  move(event: google.maps.MapMouseEvent) {
    if (event.latLng != null) this.display = event.latLng.toJSON();
  }

  book() {
    this.router.navigate(
      ['/booking'],
      { queryParams: { restaurantId: this.restaurantId, restaurantName: this.restaurantName } }
    );
  }
}
