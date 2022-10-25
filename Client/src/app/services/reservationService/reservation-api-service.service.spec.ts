import { TestBed } from '@angular/core/testing';

import { ReservationApiServiceService } from './reservation-api-service.service';

describe('ReservationApiServiceService', () => {
  let service: ReservationApiServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ReservationApiServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
