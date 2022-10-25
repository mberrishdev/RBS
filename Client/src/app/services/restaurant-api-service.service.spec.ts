import { TestBed } from '@angular/core/testing';

import { RestaurantApiServiceService } from './restaurant-api-service.service';

describe('RestaurantApiServiceService', () => {
  let service: RestaurantApiServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RestaurantApiServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
